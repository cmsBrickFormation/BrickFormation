using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityGameOverObserver : MonoBehaviour
{
    public string gameOverScene = "GameOverView";

    void Update() {
        if (PlayerPrefs.GetInt("gameover") == 1) FindObjectOfType<UtilitySceneManager>().loadScene(gameOverScene);
    }
}
