using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pink_ClassE : MonoBehaviour
{
    // Get Reference to the blue cube //
    // So we can look at it //
    public GameObject blue;

    // Refence to the bulletPrefab //
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Dest (Blue) - Orgin (Pink)
        Vector3 direction = blue.transform.position - transform.position;

        // Set the forward facing //
        transform.forward = direction;

        // Short cut method //
        //transform.LookAt(blue.transform);

        // Get user input to shoot //
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            // Spawn bullet at pink cube position and rotation //
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}
