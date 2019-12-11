﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject weapon, gun;
    AttackerSpawner myLaneSpawner;


    private void Start() {
        SetLaneSpawner();
    }

    private void SetLaneSpawner () {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners) {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnough) {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane() {
        if (myLaneSpawner.transform.childCount <= 0) {
            return false;
        } else {
            return true;
        }
    }

    public void Fire() {
        Instantiate(weapon, gun.transform.position, transform.rotation);
    }

    private void Update() {
        if (IsAttackerInLane()) {
            Debug.Log("Aight");
        } else {
            Debug.Log("Nah");
        }
    }
}
