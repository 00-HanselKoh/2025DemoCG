using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript_F : MonoBehaviour
{
    // Refenerce variables //
    public GameObject camera;
    public GameObject hook;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // When you press left mouse button //
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Do a Ray cast //
            RaycastHit hit;  // store where the "Laser" hits 

            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, camera.transform.forward, out hit, 100.0f))
            {
                print("Found an object - distance: " + hit.distance);
                print("Found an object - distance: " + hit.point);

                hook.transform.position = hit.point;

                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
            }
        }

        // Right mouse click,  teleport ourself over //
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            transform.position = hook.transform.position;
            transform.up = Vector3.up;
        }
    }
}
