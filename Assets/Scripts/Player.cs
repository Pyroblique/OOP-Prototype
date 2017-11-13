using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    public float movementSpeed = 10f;
    public float rotationSpeed = 10f;
    public float jumpHeight = 2f;
    public bool grounded = false;
    private Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //If the player is the local player
        if(isLocalPlayer)
        {
            HandleInput();
        }
    }

    // For character movement
    void Move(KeyCode key)
    {
        Vector3 position = rigid.position;
        Quaternion rotation = rigid.rotation;
        switch (key)
        {
            case KeyCode.W:
                position += transform.forward * movementSpeed * Time.deltaTime;
                break;
            case KeyCode.S:
                position += -transform.forward * movementSpeed * Time.deltaTime;
                break;
            case KeyCode.A:
                rotation *= Quaternion.AngleAxis(-rotationSpeed, Vector3.up);
                break;
            case KeyCode.D:
                rotation *= Quaternion.AngleAxis(rotationSpeed, Vector3.up);
                break;
            case KeyCode.Space:
                if (grounded)
                {
                    rigid.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                    grounded = false;
                }
                break;
        }
        rigid.MovePosition(position);
        rigid.MoveRotation(rotation);
    }

    void HandleInput()
    {
        KeyCode[] keys =
        {
            KeyCode.W,
            KeyCode.S,
            KeyCode.A,
            KeyCode.D,
            KeyCode.Space
        };

        foreach (var key in keys)
        {
            if(Input.GetKey(key))
            {
                Move(key);
            }
        }
    }

    // If the player is colliding with the ground
    void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }
}
