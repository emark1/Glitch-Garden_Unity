using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 100;
    Text healthText;
    void Start()
    {
        healthText = GetComponent<Text>();
        UpdateDisplay(); 
    }

    private void UpdateDisplay () {
        healthText.text = playerHealth.ToString();
    }

    public void LoseHealth (int amount) {
        playerHealth -= amount;

        // if health <= 0, load game over
        
        UpdateDisplay();
    }
}
