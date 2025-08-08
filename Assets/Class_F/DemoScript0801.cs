using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript0801 : MonoBehaviour
{
    public float speed = 5;
    public bool isKeyHeldDown;

    // Refence the audio Source (Speaker)
    public AudioSource audioSource;

    // Reference to the audio Clip (MP3)
    public AudioClip soundEffect1;
    public AudioClip soundEffect2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Play some sound //
            audioSource.PlayOneShot(soundEffect1);
            print("Play sound effect 1");
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            // Play some sound //
            audioSource.PlayOneShot(soundEffect2);
            print("Play sound effect 2");
        }

        //float mySpeedNow = Input.GetAxis("Horizontal") * speed;

        //float mySpeedNow = Input.GetAxisRaw("Horizontal") * speed;

        // GetAxis input //
        //print("mySpeedNow is: " + mySpeedNow);

        //if (Input.GetButtonDown("Fire1")) 
        //{
        //    print("Fire!!! ");
        //}

        /*
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            print("P is pressed!");
            isKeyHeldDown = true;
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            print("P is released!");
            isKeyHeldDown = false;
        }

        if (isKeyHeldDown == true)
        {
            print("P is held down!");
        }*/

        // When to use GetKeyUp() ? //
        // - Release a charge,
    }
}
