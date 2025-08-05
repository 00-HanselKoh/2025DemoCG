using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkCubeScript : MonoBehaviour
{
    // Need to know who to look at //
    public GameObject blueCube;

    // reference bullet prefab  /
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        // Get the direction to the blue cube //
        // Destination - Origin 
        // Blue Cube position - Pink Cube postition
        Vector3 directionVector = blueCube.transform.position - transform.position;

        // Make the pink cube face the direction //
        transform.forward = directionVector;

        // The short cut method //
        //transform.LookAt(blueCube.transform);

        // Get user input //
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            // Spawn a "Bullet" here.
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            //bullet.transform.forward = directionVector;
        }
    }
}
