using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllerMainMenu : MonoBehaviour
{
    public GameObject modeSelect, charSelect;

    void Start() {
        modeSelect.SetActive(true);
        charSelect.SetActive(false);
    }

    public void onArcadeClick() {
        PlayerPrefs.SetString("mode", "ModeArcade");
        toggleSelection();
    }

    public void onTowerClick() {
        PlayerPrefs.SetString("mode", "ModeTower");
        toggleSelection();
    }

    public void onHowToClick() => FindObjectOfType<UtilitySceneManager>().loadScene("HowToPlay");

    public void onQuitClick() => Application.Quit();

    public void onCancelClick() {
        toggleSelection();
        PlayerPrefs.SetInt("cancelselect", 1);
    }

    public void onStartClick() {
        FindObjectOfType<UtilityPlayerIdentifier>().identifyPlayers();
        FindObjectOfType<UtilitySceneManager>().loadScene(PlayerPrefs.GetString("mode"));
    }

    private void toggleSelection() {
        modeSelect.SetActive(!modeSelect.activeInHierarchy);
        charSelect.SetActive(!charSelect.activeInHierarchy);
    }
}
