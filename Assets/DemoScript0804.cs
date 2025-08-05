using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript0804 : MonoBehaviour
{
    // Reference to audio Source
    public AudioSource speaker;

    // Reference to audio Clip 
    public AudioClip mp3_1;
    public AudioClip mp3_2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get key input p key 
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            speaker.PlayOneShot(mp3_1);
        }

        // Get key input o key 
        if (Input.GetKeyDown(KeyCode.O))
        {
            speaker.PlayOneShot(mp3_2);
        }

        // Get key input o key 
        if (Input.GetKeyDown(KeyCode.I))
        {
            //speaker.PlayOneShot(mp3_2);
            speaker.Play();
        }
    }
}
