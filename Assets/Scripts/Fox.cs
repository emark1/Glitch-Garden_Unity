using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{

    Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D otherCollider) {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.name == "Tombstone" ^ otherObject.name == "Tombstone(Clone)") {
            animator.SetTrigger("isJumping");
        } else if (otherObject.GetComponent<Defender>()) {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }


}
