using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassE_Character : MonoBehaviour
{
    public float speed;

    // Reference to the animator //
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Simple user input to move forward //
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 
                                        0, 
                                        Input.GetAxis("Vertical"));

        // Check if there is user input to the direction //
        if (direction.magnitude > 0)
        {
            // Move character, in the direction and multiply by the speed over time //
            transform.position += direction * speed * Time.deltaTime;

            // Make the character face the direction it's moving //
            transform.forward = direction;
        }

        // Change the speed in the animator depending on the speed //
        animator.SetFloat("Speed", (direction * speed).magnitude);

        // Example: 
        // direction - (1, 0, 1)
        // direction.magnitude = 0.9
        // direction * speed - (1, 0, 1) * 5 = (5, 0, 5)
        // (direction * speed).magnitude = 4.5 


        // Add a Key input for testing //
        // Do replace this condition to (health <= 0) for your game //
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            // Trigger the isDead variable in the animator controller //
            animator.SetTrigger("isDead");
        }
    }
}
