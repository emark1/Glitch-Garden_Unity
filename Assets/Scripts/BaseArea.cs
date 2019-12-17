using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseArea : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerHealth playerHealth;
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D enemy) {
        if (enemy.GetComponent<Attacker>()) {
            playerHealth.LoseHealth();
        }
    }

}
