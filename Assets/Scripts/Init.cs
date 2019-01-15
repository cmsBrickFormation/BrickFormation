using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    public string nextScene = "SplashscreenFH";

    void Awake() {
        initializePlayerPrefs();
        FindObjectOfType<UtilitySceneManager>().loadScene(nextScene);
    }

    private void initializePlayerPrefs() {
        PlayerPrefs.SetString("mode", "");
        PlayerPrefs.SetInt("gameover", 0);
        PlayerPrefs.SetInt("cancelselect", 0);
        PlayerPrefs.SetInt("playercount", 0);
        PlayerPrefs.SetInt("charp1", 99);
        PlayerPrefs.SetInt("charp2", 99);
        PlayerPrefs.SetInt("charp3", 99);
        PlayerPrefs.SetInt("charp4", 99);
        PlayerPrefs.SetInt("playerready", 0);
        PlayerPrefs.SetInt("scorep1", 0);
        PlayerPrefs.SetInt("scorep2", 0);
        PlayerPrefs.SetInt("scorep3", 0);
        PlayerPrefs.SetInt("scorep4", 0);
        PlayerPrefs.SetInt("brickcountp1", 0);
        PlayerPrefs.SetInt("brickcountp2", 0);
        PlayerPrefs.SetInt("brickcountp3", 0);
        PlayerPrefs.SetInt("brickcountp4", 0);
        PlayerPrefs.SetInt("winnerp1", 0);
        PlayerPrefs.SetInt("winnerp2", 0);
        PlayerPrefs.SetInt("winnerp3", 0);
        PlayerPrefs.SetInt("winnerp4", 0);
        PlayerPrefs.SetInt("defaultlivesnumber", 25);
        PlayerPrefs.SetFloat("livesp1", PlayerPrefs.GetInt("defaultlivesnumber"));
        PlayerPrefs.SetFloat("livesp2", PlayerPrefs.GetInt("defaultlivesnumber"));
        PlayerPrefs.SetFloat("livesp3", PlayerPrefs.GetInt("defaultlivesnumber"));
        PlayerPrefs.SetFloat("livesp4", PlayerPrefs.GetInt("defaultlivesnumber"));
    }
}
