using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerScript_E : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // New function to detect collision enter state //
    private void OnCollisionEnter(Collision collision)
    {
        // Check who collided ? //
        if (collision.gameObject.tag == "Player") 
        {
            print("Touch player!!");

            // Tell gameManager to add 5 health
            GameManager_E.instance.AddHealth(5);  
        }
    }
}
