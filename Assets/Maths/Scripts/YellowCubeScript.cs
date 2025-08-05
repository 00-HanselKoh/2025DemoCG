using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCubeScript : MonoBehaviour
{
    public float speed;
    public float distance;

    // Update is called once per frame
    void Update()
    {
        // formula: Direction * Ocscillation * distance * deltaTime
        transform.position += Vector3.right * Mathf.Cos(Time.time * speed) * distance * Time.deltaTime;
    }
}
