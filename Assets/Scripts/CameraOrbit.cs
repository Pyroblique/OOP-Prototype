using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    public float minimumY = -90f;
    public float maximumY = 90f;

    private float yaw = 0f;
    private float pitch = 0f;
    private GameObject mainCamera;

    // Use this for initialization
    void Start()
    {
        // Lock the mouse
        Cursor.lockState = CursorLockMode.Locked; //(didn't realise it was this easy)
        // Hide cursor
        Cursor.visible = false;
        Camera cam = GetComponentInChildren<Camera>();
        if(cam != null)
        {
            mainCamera = cam.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
      //  if(isLocalPlayer)
        {
            HandleInput();
        }
    }

    void OnDestroy()
    {
        //Unlock cursor
        Cursor.lockState = CursorLockMode.None;
        //Unhide cursor
        Cursor.visible = true;
    }

    void HandleInput()
    {
   //     yaw = 
    }
}
