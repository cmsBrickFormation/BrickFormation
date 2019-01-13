using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadePlayerCharController : MonoBehaviour
{
    public int playerNum;

    void Update() {
        if (playerNum == 1 && FindObjectOfType<ArcadeGridP1>().isGameOver) this.gameObject.transform.position += new Vector3(0, -0.25f, 0);
        else if (playerNum == 2 && FindObjectOfType<ArcadeGridP2>().isGameOver) this.gameObject.transform.position += new Vector3(0, -0.25f, 0);
        else if (playerNum == 3 && FindObjectOfType<ArcadeGridP3>().isGameOver) this.gameObject.transform.position += new Vector3(0, -0.25f, 0);
        else if (playerNum == 4 && FindObjectOfType<ArcadeGridP4>().isGameOver) this.gameObject.transform.position += new Vector3(0, -0.25f, 0);

        if (this.gameObject.transform.position.y < -10) {
            PlayerPrefs.SetInt("gameover", PlayerPrefs.GetInt("gameover") + 1);
            Destroy(this.gameObject);
        }
    }
}
