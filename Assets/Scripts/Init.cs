using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    public string nextScene = "SplashscreenFH";

    void Awake() {
        initializePlayerPrefs();
        FindObjectOfType<UtilitySceneManager>().loadScene(nextScene);
    }

    private void initializePlayerPrefs() {
        PlayerPrefs.SetString("mode", "");
        PlayerPrefs.SetInt("gameover", 0);
    }
}
