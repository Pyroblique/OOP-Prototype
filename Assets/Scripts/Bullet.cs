using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the bullet
        transform.Translate(Vector3.forward / 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Zombie>() != null)
        {
            // Destroy object
            Destroy(gameObject);
        }
    }
}
