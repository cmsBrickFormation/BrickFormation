using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityEscapeRope : MonoBehaviour
{
    public string emergencyExit = "MainMenu";

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) FindObjectOfType<UtilitySceneManager>().loadScene(emergencyExit);
    }
}
