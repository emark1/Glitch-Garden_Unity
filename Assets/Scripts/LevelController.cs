using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    void Start()
    {
        
    }

    public void AttackerSpawned() {
        numberOfAttackers += 1;
    }

    public void AttackerKilled() {
        numberOfAttackers -= 1;
        if ( numberOfAttackers <= 0 && levelTimerFinished) {
            Debug.Log("END LEVEL NOOOOW");
        }
    }

    public void LevelTimerFinished() {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners() {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray) {
            spawner.StopSpawning();
        }
    }


}
