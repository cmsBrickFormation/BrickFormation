using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitArcade : MonoBehaviour
{
    void Start() {
        PlayerPrefs.SetString("mode", "arcade");
    }
}
