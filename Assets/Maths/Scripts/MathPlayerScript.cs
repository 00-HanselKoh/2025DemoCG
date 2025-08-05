using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathPlayerScript : MonoBehaviour
{
    public float speed;         // For the speed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Key inputs w, a, s, d. And the formula of Direction * Speed * delta Time 
        if (Input.GetKey(KeyCode.W))        // To move forward 
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))   // To move backward
        {
            transform.position -= Vector3.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))        // To move right
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))   // To move left
        {
            transform.position -= Vector3.right * speed * Time.deltaTime;
        }
    }
}
