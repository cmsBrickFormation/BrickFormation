using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UtilityGameOverController : MonoBehaviour
{
    public GameObject scoreTextP1;
    public GameObject scoreTextP2;
    public GameObject scoreTextP3;
    public GameObject scoreTextP4;
    public GameObject highScoreText;
    public GameObject highScoreIndicator;
    private bool isNewHighScore = false;

    void Awake() {
        if (PlayerPrefs.GetInt("playercount") == 1) {
            scoreTextP1.gameObject.GetComponent<Text>().text = "P1 - " + PlayerPrefs.GetInt("scorep1");
            scoreTextP2.SetActive(false);
            scoreTextP3.SetActive(false);
            scoreTextP4.SetActive(false);
        } else if (PlayerPrefs.GetInt("playercount") == 2) {
            scoreTextP1.gameObject.GetComponent<Text>().text = "P1 - " + PlayerPrefs.GetInt("scorep1");
            scoreTextP2.gameObject.GetComponent<Text>().text = "P2 - " + PlayerPrefs.GetInt("scorep2");
            scoreTextP3.SetActive(false);
            scoreTextP4.SetActive(false);
        } else if (PlayerPrefs.GetInt("playercount") == 3) {
            scoreTextP1.gameObject.GetComponent<Text>().text = "P1 - " + PlayerPrefs.GetInt("scorep1");
            scoreTextP2.gameObject.GetComponent<Text>().text = "P2 - " + PlayerPrefs.GetInt("scorep2");
            scoreTextP3.gameObject.GetComponent<Text>().text = "P3 - " + PlayerPrefs.GetInt("scorep3");
            scoreTextP4.SetActive(false);
        } else if (PlayerPrefs.GetInt("playercount") == 4) {
            scoreTextP1.gameObject.GetComponent<Text>().text = "P1 - " + PlayerPrefs.GetInt("scorep1");
            scoreTextP2.gameObject.GetComponent<Text>().text = "P2 - " + PlayerPrefs.GetInt("scorep2");
            scoreTextP3.gameObject.GetComponent<Text>().text = "P3 - " + PlayerPrefs.GetInt("scorep3");
            scoreTextP4.gameObject.GetComponent<Text>().text = "P4 - " + PlayerPrefs.GetInt("scorep4");
        }
        if (PlayerPrefs.GetInt("scorep1") > PlayerPrefs.GetInt("highscore")) setNewHighScore(PlayerPrefs.GetInt("scorep1"));
        if (PlayerPrefs.GetInt("scorep2") > PlayerPrefs.GetInt("highscore")) setNewHighScore(PlayerPrefs.GetInt("scorep2"));
        if (PlayerPrefs.GetInt("scorep3") > PlayerPrefs.GetInt("highscore")) setNewHighScore(PlayerPrefs.GetInt("scorep3"));
        if (PlayerPrefs.GetInt("scorep4") > PlayerPrefs.GetInt("highscore")) setNewHighScore(PlayerPrefs.GetInt("scorep4"));

        highScoreText.gameObject.GetComponent<Text>().text = "High-Score: " + PlayerPrefs.GetInt("highscore");
        if (!isNewHighScore) highScoreIndicator.SetActive(false);
    }

    void Start() {
        PlayerPrefs.SetInt("scorep1", 0);
        PlayerPrefs.SetInt("scorep2", 0);
        PlayerPrefs.SetInt("scorep3", 0);
        PlayerPrefs.SetInt("scorep4", 0);
    }

    void setNewHighScore(int newScore) {
        isNewHighScore = true;
        PlayerPrefs.SetInt("highscore", newScore);
    }
}
