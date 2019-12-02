using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    // [Range (0f, 5f)][SerializeField] float walkSpeed = 1f;
    float currentSpeed = 0f;

    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    private void Move () {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float speed) {
        currentSpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer) {
        health -= damageDealer.GetDamage();
        damageDealer.DestroyProjectile();
        if (health <= 0) {
            KillAttacker();
        }
    }

    private void KillAttacker () {
        GameObject deathSplatter = Instantiate(deathVFX, transform.position, transform.rotation) as GameObject;
        Destroy(deathSplatter, 1f);
        Destroy(gameObject);
    }
}
