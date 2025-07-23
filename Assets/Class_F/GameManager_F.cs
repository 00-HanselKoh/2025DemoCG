using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager_F : MonoBehaviour
{
    // Using static to make sure the game has only copy //
    public static GameManager_F instance;

    // Variable to store the health //
    private float health;

    // Reference to the UI //
    public TextMeshProUGUI scoreText;

    // Reference to the AudioSource //
    private AudioSource audioSource;

    // Reference of the AudioClip //
    public AudioClip[] healSoundArr;

    // Reference for the BGM 1 and 2 //
    public AudioClip BGM1;
    public AudioClip BGM2;
    public AudioClip BGMHealing;

    // Start is called before the first frame update
    void Start()
    {
        // store this class into the instance variable //
        instance = this;

        // Start health with 100 //
        health = 100;

        // Display the current health onto the screen //
        scoreText.text = "Health: " + this.health;

        // Get reference to the AudioSoirce component //
        audioSource = GetComponent<AudioSource>();
    }

    // Create a function to add health //
    public void AddHealth(int _health) 
    {
        // Add health //
        this.health += _health;

        // Make sure health is not more than 200 //
        this.health = (this.health >= 200) ? 200 : this.health;

        // Display the current health onto the console //
        print("this.health: " + this.health);

        // Display the current health onto the screen //
        scoreText.text = "Health: " + (int)this.health;

        // Play some sound //
        audioSource.PlayOneShot(healSoundArr[Random.Range(0, healSoundArr.Length)]);
    }

    public void AddHealth(float _health)
    {
        // Add health //
        this.health += _health;

        // Make sure health is not more than 200 //
        this.health = (this.health >= 200) ? 200 : this.health;
        // Conditional statement //
        // (condition) ? <true> : <false>

        // Display the current health onto the console //
        print("this.health: " + this.health);

        // Display the current health onto the screen //
        scoreText.text = "Health: " + (int)this.health;
        // Play some sound //
        //audioSource.PlayOneShot(healSoundArr[Random.Range(0, healSoundArr.Length)]);
    }

    public void PlayBGM1() 
    {
        audioSource.clip = BGM1;
        audioSource.Play();
    }

    public void PlayBGM2()
    {
        audioSource.clip = BGM2;
        audioSource.Play();
    }

    public void PlayBGMHealing()
    {
        audioSource.clip = BGMHealing;
        audioSource.Play();
    }
}
