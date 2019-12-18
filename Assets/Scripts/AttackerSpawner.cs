using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float spawnCounter;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] List<Attacker> attackerList;

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

    public void StopSpawning() {
        spawn = false;
    }

    private void SpawnAttacker() {
        var randomNum = Random.Range(0, attackerList.Count);
        Spawn(randomNum);
    }

    private void Spawn(int index) {
        Attacker newAttacker = Instantiate(attackerList[index], transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
