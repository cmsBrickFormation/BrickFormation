using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllerGameOver : MonoBehaviour
{
    public string sceneNameBackToMenu = "MainMenu";

    public void playAgain() => FindObjectOfType<UtilitySceneManager>().loadScene(PlayerPrefs.GetString("mode"));

    public void backToMenu() {
        PlayerPrefs.SetInt("playercount", 0);
        PlayerPrefs.SetInt("charp1", 99);
        PlayerPrefs.SetInt("charp2", 99);
        PlayerPrefs.SetInt("charp3", 99);
        PlayerPrefs.SetInt("charp4", 99);
        FindObjectOfType<UtilitySceneManager>().loadScene(sceneNameBackToMenu);
    }
}
