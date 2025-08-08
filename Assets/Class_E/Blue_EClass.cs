using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_EClass : MonoBehaviour
{
    public float speed = 5;
    public GameObject pinkCube;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Cos(Time.time) * speed, 
                                         Mathf.Sin(Time.time) * speed, 
                                         0);

        // To look at the pink guy //
        // Direction =  Pink - Blue /
        Vector3 direction = pinkCube.transform.position - transform.position;
        transform.forward = direction;
    }
}
