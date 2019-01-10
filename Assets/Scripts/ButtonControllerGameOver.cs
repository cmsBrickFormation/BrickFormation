using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllerGameOver : MonoBehaviour
{
    public string sceneNamePlayAgain = "ModeArcade";
    public string sceneNameBackToMenu = "MainMenu";

    public void playAgain() {
        FindObjectOfType<UtilitySceneManager>().loadScene(sceneNamePlayAgain);
    }

    public void backToMenu() {
        FindObjectOfType<UtilitySceneManager>().loadScene(sceneNameBackToMenu);
    }
}
