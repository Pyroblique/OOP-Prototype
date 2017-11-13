using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        // To shoot
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
