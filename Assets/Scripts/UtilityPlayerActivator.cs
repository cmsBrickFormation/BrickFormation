using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityPlayerActivator : MonoBehaviour
{
    public int playerNumber;
    public GameObject inactiveState, activeState;

    void Start() => deactivate();

    void Update() {
        if (playerNumber == 1 && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) activate(1);
        else if (playerNumber == 2 && Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.I) && Input.GetKey(KeyCode.L)) activate(2);
        else if (playerNumber == 3 && Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)) activate(3);
        else if (playerNumber == 4 && Input.GetKey(KeyCode.Keypad4) && Input.GetKey(KeyCode.Keypad8) && Input.GetKey(KeyCode.Keypad6)) activate(4);

        if (PlayerPrefs.GetInt("cancelselect") == 1) {
            PlayerPrefs.SetInt("playercount", 0);
            deactivate();
        }
    }

    private void activate(int playerNum) {
        inactiveState.SetActive(false);
        activeState.SetActive(true);
        PlayerPrefs.SetInt("cancelselect", 0);
        PlayerPrefs.SetInt("playercount", playerNum);
        PlayerPrefs.SetInt("playerready", 1);
    }

    private void deactivate() {
        inactiveState.SetActive(true);
        activeState.SetActive(false);
        PlayerPrefs.SetInt("playerready", 0);
    }
}
