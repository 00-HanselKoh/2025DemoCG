using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadyScript_F : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float health;

    private void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        // User input //
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetFloat("Speed", 2);
                transform.position += transform.forward * (speed * 2) * Time.deltaTime;
            }
            else 
            {
                animator.SetFloat("Speed", 1);
                transform.position += transform.forward * speed * Time.deltaTime;
            }
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        // Use P to minus health //
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            health -= 10;
            print("Health: " + health);

            if (health <= 0)        // Check is the health is less than 0 //
            {
                animator.SetTrigger("isDead");  // Then play dead Animation //
            }
        }
    }
}
