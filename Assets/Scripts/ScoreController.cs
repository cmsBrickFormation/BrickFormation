using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public int playerNumber;

    void Start() {
        if (playerNumber == 1) PlayerPrefs.SetInt("scorep1", 0);
        else if (playerNumber == 2) PlayerPrefs.SetInt("scorep2", 0);
        else if (playerNumber == 3) PlayerPrefs.SetInt("scorep3", 0);
        else if (playerNumber == 4) PlayerPrefs.SetInt("scorep4", 0);
    }

    void Update() {
        if (playerNumber == 1) this.gameObject.GetComponent<TextMesh>().text = "Score: " + PlayerPrefs.GetInt("scorep1");
        else if (playerNumber == 2) this.gameObject.GetComponent<TextMesh>().text = "Score: " + PlayerPrefs.GetInt("scorep2");
        else if (playerNumber == 3) this.gameObject.GetComponent<TextMesh>().text = "Score: " + PlayerPrefs.GetInt("scorep3");
        else if (playerNumber == 4) this.gameObject.GetComponent<TextMesh>().text = "Score: " + PlayerPrefs.GetInt("scorep4");
    }
}
