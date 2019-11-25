using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float spawnCounter;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker attackerType;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do {
            yield return StartCoroutine(CountDownAndSpawn());
        } while (spawn);
    }

    IEnumerator CountDownAndSpawn () {
        spawnCounter = Random.Range(minSpawnDelay,maxSpawnDelay);
        yield return new WaitForSeconds(spawnCounter);
        SpawnAttacker();
    }

    private void SpawnAttacker() {
        Instantiate(attackerType, transform.position, transform.rotation);
    }
}
