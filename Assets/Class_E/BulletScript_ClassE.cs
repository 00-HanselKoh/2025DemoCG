using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript_ClassE : MonoBehaviour
{
    public float speed;

    // reference to blue //
    public GameObject blueCube;

    // Start is called before the first frame update
    void Start()
    {
        // Destroy after 3 sec //
        Destroy(gameObject, 3);

        // Find the blue cube //
        blueCube = GameObject.Find("BlueCube");
    }

    // Update is called once per frame
    void Update()
    {
        // Make the bullet move forward //
        // Moving forward = direction * speed * deltaTime;
        // transform.position += transform.forward * speed * Time.deltaTime;

        // direction to blue //
        // direction: blue cube - bullet //
        Vector3 direction = blueCube.transform.position - transform.position;
        float distanceLeft = direction.magnitude;

        // Normalised the vector //
        direction.Normalize();

        transform.position += direction * speed * Time.deltaTime;

        // Problem 1 - Orientate the bullet to the direction its moving
        transform.forward = direction;

        // Problem 2 - Destory the bullet when it near the blue cube. (Distance - Magnititude)
        if (distanceLeft < 1)
        {
            Destroy(gameObject);
        }
    }
}
