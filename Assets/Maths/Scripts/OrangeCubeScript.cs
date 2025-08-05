using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeCubeScript : MonoBehaviour
{
    public float speed;
    public float distance;

    // Update is called once per frame
    void Update()
    {
        // formula: Direction * Ocscillation * distance * deltaTime
        transform.position += Vector3.up * Mathf.Cos(Time.time * speed) * distance * Time.deltaTime;
    }
}
