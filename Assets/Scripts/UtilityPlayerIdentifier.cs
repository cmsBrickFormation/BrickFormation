using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityPlayerIdentifier : MonoBehaviour
{
    public GameObject charWindowP1, charWindowP2, charWindowP3, charWindowP4;

    public void identifyPlayers() {
        PlayerPrefs.SetInt("charp1", charWindowP1.GetComponent<ButtonControllerCharWindow>().activeIndex);
        PlayerPrefs.SetInt("charp2", charWindowP2.GetComponent<ButtonControllerCharWindow>().activeIndex);
        PlayerPrefs.SetInt("charp3", charWindowP3.GetComponent<ButtonControllerCharWindow>().activeIndex);
        PlayerPrefs.SetInt("charp4", charWindowP4.GetComponent<ButtonControllerCharWindow>().activeIndex);
    }
}
