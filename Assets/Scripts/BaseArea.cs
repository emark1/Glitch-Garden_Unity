using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseArea : MonoBehaviour
{
    PlayerHealth playerHealth;
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D enemy) {
        if (enemy.GetComponent<Attacker>()) {
            playerHealth.LoseHealth();
        }
    }

}
