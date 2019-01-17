using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{

    public int playerNumber;
    public GameObject timerText;
    private int timer = 300;
    private string prefKeyWinner, prefKeyScore;
    private bool timerActive = false;

    void Start() {
        prefKeyWinner = "winnerp" + playerNumber;
        prefKeyScore = "scorep" + playerNumber;
    }

    void Update() {
        timerText.GetComponent<TextMesh>().text = "" + timer;
        if (timerActive) timer--;
        if (timer <= 0) {
            PlayerPrefs.SetInt(prefKeyWinner, 1);
            PlayerPrefs.SetInt(prefKeyScore, PlayerPrefs.GetInt(prefKeyScore) + 2500);
            enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        GameObject collidedBrick = other.gameObject.transform.parent.gameObject;
        if (playerNumber == 1 && collidedBrick.GetComponent<TowerBrickP1>().released) timerActive = true;
        else if (playerNumber == 2 && collidedBrick.GetComponent<TowerBrickP2>().released) timerActive = true;
        else if (playerNumber == 3 && collidedBrick.GetComponent<TowerBrickP3>().released) timerActive = true;
        else if (playerNumber == 4 && collidedBrick.GetComponent<TowerBrickP4>().released) timerActive = true;
    }

    private void OnTriggerExit(Collider other) {
        timer = 300;
        timerActive = false;
    }
}
