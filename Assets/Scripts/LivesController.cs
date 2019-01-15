using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    public int playerNumber;

    void Update() {
        if (playerNumber == 1) this.gameObject.GetComponent<TextMesh>().text = "Lives: " + PlayerPrefs.GetFloat("livesp1");
        else if (playerNumber == 2) this.gameObject.GetComponent<TextMesh>().text = "Lives: " + PlayerPrefs.GetFloat("livesp2");
        else if (playerNumber == 3) this.gameObject.GetComponent<TextMesh>().text = "Lives: " + PlayerPrefs.GetFloat("livesp3");
        else if (playerNumber == 4) this.gameObject.GetComponent<TextMesh>().text = "Lives: " + PlayerPrefs.GetFloat("livesp4");
    }
}
