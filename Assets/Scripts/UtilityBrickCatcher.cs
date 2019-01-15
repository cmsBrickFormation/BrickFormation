using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityBrickCatcher : MonoBehaviour
{
    public int playerNumber;

    private void OnTriggerEnter(Collider brick) {
        updatePlayerLives(playerNumber);
        Destroy(brick.gameObject);
    }

    private void updatePlayerLives(int playerNumber) {
        switch (playerNumber) {
            case 1:
                PlayerPrefs.SetFloat("livesp1", PlayerPrefs.GetFloat("livesp1") - 0.25f);
                break;
            case 2:
                PlayerPrefs.SetFloat("livesp2", PlayerPrefs.GetFloat("livesp2") - 0.25f);
                break;
            case 3:
                PlayerPrefs.SetFloat("livesp3", PlayerPrefs.GetFloat("livesp3") - 0.25f);
                break;
            case 4:
                PlayerPrefs.SetFloat("livesp4", PlayerPrefs.GetFloat("livesp4") - 0.25f);
                break;
        }
    }
}
