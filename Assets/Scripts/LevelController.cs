using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    [SerializeField] GameObject winLabel;
    [SerializeField] float waitToLoad = 3;

    void Start()
    {
        winLabel.SetActive(false);
    }

    public void AttackerSpawned() {
        numberOfAttackers += 1;
    }

    public void AttackerKilled() {
        numberOfAttackers -= 1;
        if ( numberOfAttackers <= 0 && levelTimerFinished) {
            StartCoroutine(HandlWinCondition());
        }
    }

    IEnumerator HandlWinCondition () {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
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
