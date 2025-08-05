using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Ryan say we need to know our target //
    public GameObject target;

    public float speed;

    private void Start()
    {
        // We can say who is the target //
        target = GameObject.Find("BlueCube");
    }

    // Update is called once per frame
    void Update()
    {
        // Face the target //
        transform.LookAt(target.transform);

        // Move forward 
        // Direction * speed * time.deltaTime
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
