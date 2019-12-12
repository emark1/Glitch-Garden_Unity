using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    [SerializeField] float health = 100f;

    public void DealDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX() {
        if(!TriggerDeathVFX) {return;}
        GameObject deathVFXObject = Instantiate(deathVFXObject, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
