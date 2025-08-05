using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCubeScript : MonoBehaviour
{
    public float speed;
    public float distance;

    // Update is called once per frame
    void Update()
    {
        // Using Cos and Sin, to make it move in the circle //
        transform.position = new Vector3(Mathf.Cos(Time.time) * speed * distance ,
                                         5 + Mathf.Sin(Time.time) * speed * distance, 
                                         0);
    }
}
