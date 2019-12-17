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

    public void LoseHealth () {
        playerHealth -= 10;

        if (playerHealth <= 0) {
            FindObjectOfType<LevelLoader>().Lose();
        }

        UpdateDisplay();
    }
}
