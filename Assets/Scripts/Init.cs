using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    public string nextScene = "SplashscreenFH";

    void Awake() {
        initializePlayerPrefs();
        SceneManager.LoadScene(nextScene);
    }

    private void initializePlayerPrefs() {

    }
}
