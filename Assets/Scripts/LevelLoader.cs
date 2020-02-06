using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int waitSeconds = 3;
    int currentScene;

    public void StartRoutine() {
        StartCoroutine(WaitToLoad());
    }

    IEnumerator WaitToLoad() {
        yield return new WaitForSeconds(waitSeconds);
        LoadNextScene();
    }

    public void LoadNextScene () {
        SceneManager.LoadScene(currentScene + 1);
    }

    public void LoadOptions () {
        SceneManager.LoadScene("OptionsScreen");
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("StartScreen");
    }

    void Start () {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 0) {
            StartRoutine();
        }
    }

    public void Lose () {
        SceneManager.LoadScene("GameOver");
    }
}
