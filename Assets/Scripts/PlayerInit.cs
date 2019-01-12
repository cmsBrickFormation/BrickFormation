using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInit : MonoBehaviour
{
    public int playerNumber;
    public GameObject playerCam, playerChar, playerGrid;
    public GameObject[] chars;
    public Material[] charMaterials;
    public Material charMaterial;

    private void Awake() {
        // disable current object if not needed
        if (PlayerPrefs.GetInt("playercount") == 1 && playerNumber > 1) this.gameObject.SetActive(false);
        else if (PlayerPrefs.GetInt("playercount") == 2 && playerNumber > 2) this.gameObject.SetActive(false);
        else if (PlayerPrefs.GetInt("playercount") == 3 && playerNumber > 3) this.gameObject.SetActive(false);
    }

    void Start() {
        // Adjust camera position for splitscreen
        if (PlayerPrefs.GetInt("playercount") == 1) setCam(1, playerNumber, playerCam);
        else if (PlayerPrefs.GetInt("playercount") == 2) setCam(2, playerNumber, playerCam);
        else if (PlayerPrefs.GetInt("playercount") == 3) setCam(3, playerNumber, playerCam);

        // load the correct char
        Instantiate(chars[PlayerPrefs.GetInt("charp" + playerNumber)], playerChar.transform);

        // set the correct grid color
        Transform[] gridCubes = playerGrid.gameObject.GetComponentsInChildren<Transform>();
        charMaterial = charMaterials[PlayerPrefs.GetInt("charp" + playerNumber)];
        for (int i = 1; i < gridCubes.Length; i++) gridCubes[i].gameObject.GetComponent<MeshRenderer>().material = charMaterial;
    }

    private void setCam(int playerCount, int playerNum, GameObject cam) {
        if (playerCount == 1) cam.gameObject.GetComponent<Camera>().rect = new Rect(0, 0, 1, 1);
        else if (playerCount == 2) {
            if (playerNum == 1) cam.gameObject.GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 1);
            else if (playerNum == 2) cam.gameObject.GetComponent<Camera>().rect = new Rect(0.5f, 0, 0.5f, 1);
        }
        else if (playerCount == 3) {
            if (playerNum == 1) cam.gameObject.GetComponent<Camera>().rect = new Rect(0, 0, 0.333f, 1);
            else if (playerNum == 2) cam.gameObject.GetComponent<Camera>().rect = new Rect(0.333f, 0, 0.333f, 1);
            else if (playerNum == 3) cam.gameObject.GetComponent<Camera>().rect = new Rect(0.666f, 0, 0.333f, 1);
        }
    }
}
