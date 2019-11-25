using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject weapon, gun;

    public void Fire() {
        Instantiate(weapon, gun.transform.position, transform.rotation);
    }
}
