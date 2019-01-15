using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeInit : MonoBehaviour
{
    void Start() => setPlayerPrefs();

    void setPlayerPrefs() {
        PlayerPrefs.SetInt("winnerp1", 0);
        PlayerPrefs.SetInt("winnerp2", 0);
        PlayerPrefs.SetInt("winnerp3", 0);
        PlayerPrefs.SetInt("winnerp4", 0);
        PlayerPrefs.SetFloat("livesp1", PlayerPrefs.GetInt("defaultlivesnumber"));
        PlayerPrefs.SetFloat("livesp2", PlayerPrefs.GetInt("defaultlivesnumber"));
        PlayerPrefs.SetFloat("livesp3", PlayerPrefs.GetInt("defaultlivesnumber"));
        PlayerPrefs.SetFloat("livesp4", PlayerPrefs.GetInt("defaultlivesnumber"));
        PlayerPrefs.SetInt("scorep1", 0);
        PlayerPrefs.SetInt("scorep2", 0);
        PlayerPrefs.SetInt("scorep3", 0);
        PlayerPrefs.SetInt("scorep4", 0);
        PlayerPrefs.SetInt("gameover", 0);
    }
}
