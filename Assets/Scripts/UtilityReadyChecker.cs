using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityReadyChecker : MonoBehaviour
{
    public GameObject startButton;

    void Start() => startButton.SetActive(false);

    void Update() {
        if (PlayerPrefs.GetInt("playerready") == 1) startButton.SetActive(true);
        if (PlayerPrefs.GetInt("cancelselect") == 1) startButton.SetActive(false);
    }
}
