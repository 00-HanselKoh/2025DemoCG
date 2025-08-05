using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add namespace for textmeshpro 
using TMPro;

public class GameManager_E : MonoBehaviour
{
    public static GameManager_E instance;
    public int health;

    // Have reference to the text box to update heatlh //
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        // keep a reference of ourself //
        instance = this;

        // Start with how much health //
        health = 1;

        // Display health onto screen //
        healthText.text = "Health: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // A function to add health //
    public void AddHealth(int healthToAdd) 
    {
        health += healthToAdd;

        // Display on the console the total health now //
        print("Health: " + health);

        // Display health onto screen //
        healthText.text = "Health: " + health;
    }
}
