﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 0f;
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;
    GameObject currentTarget;
    Animator animator;

    void Awake () {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy() {
        FindObjectOfType<LevelController>().AttackerKilled();
    }

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        Move();
        UpdateAnimationState();
    }

    private void UpdateAnimationState () {
        if (!currentTarget) {
            animator.SetBool("IsAttacking", false);
        }
    }

    public void Attack(GameObject target) {
        animator.SetBool("IsAttacking", true);
        currentTarget = target;
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

    public void StrikeTarget (float damage) {
        if (!currentTarget) {
            return;
        }

        Health defenderHealth = currentTarget.GetComponent<Health>();
        if (defenderHealth) {
            defenderHealth.DealDamage(damage);
        }
    }
}
