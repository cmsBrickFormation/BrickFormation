using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeInit : MonoBehaviour
{
    void Start() {
        PlayerPrefs.SetString("mode", "ModeArcade");
        PlayerPrefs.SetInt("gameover", 0);
    }
}
