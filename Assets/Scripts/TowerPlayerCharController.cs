using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlayerCharController : MonoBehaviour
{
    public int playerNum;

    void Update() {
        if (playerNum == 1 && FindObjectOfType<TowerPlatformP1>().isGameOver) this.gameObject.transform.position += new Vector3(0, -0.25f, 0);
        else if (playerNum == 2 && FindObjectOfType<TowerPlatformP2>().isGameOver) this.gameObject.transform.position += new Vector3(0, -0.25f, 0);
        else if (playerNum == 3 && FindObjectOfType<TowerPlatformP3>().isGameOver) this.gameObject.transform.position += new Vector3(0, -0.25f, 0);
        else if (playerNum == 4 && FindObjectOfType<TowerPlatformP4>().isGameOver) this.gameObject.transform.position += new Vector3(0, -0.25f, 0);

        if (this.gameObject.transform.position.y < -10) {
            PlayerPrefs.SetInt("gameover", PlayerPrefs.GetInt("gameover") + 1);
            Destroy(this.gameObject);
        }
    }
}
