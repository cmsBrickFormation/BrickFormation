using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UtilityGameOverController : MonoBehaviour
{
    public GameObject scoreTextP1, scoreTextP2, scoreTextP3, scoreTextP4;
    public GameObject brickCountTextP1, brickCountTextP2, brickCountTextP3, brickCountTextP4;
    public GameObject highScoreText;
    public GameObject highScoreIndicator;
    private bool isNewHighScore = false;
    private bool isNewHighCount = false;

    void Awake() {
        if (PlayerPrefs.GetInt("playercount") == 1) {
            scoreTextP1.gameObject.GetComponent<Text>().text = "P1 - " + PlayerPrefs.GetInt("scorep1");
            brickCountTextP1.gameObject.GetComponent<Text>().text = "" + PlayerPrefs.GetInt("brickcountp1");
            scoreTextP2.SetActive(false);
            brickCountTextP2.SetActive(false);
            scoreTextP3.SetActive(false);
            brickCountTextP3.SetActive(false);
            scoreTextP4.SetActive(false);
            brickCountTextP4.SetActive(false);
        } else if (PlayerPrefs.GetInt("playercount") == 2) {
            scoreTextP1.gameObject.GetComponent<Text>().text = "P1 - " + PlayerPrefs.GetInt("scorep1");
            brickCountTextP1.gameObject.GetComponent<Text>().text = "" + PlayerPrefs.GetInt("brickcountp1");
            scoreTextP2.gameObject.GetComponent<Text>().text = "P2 - " + PlayerPrefs.GetInt("scorep2");
            brickCountTextP2.gameObject.GetComponent<Text>().text = "" + PlayerPrefs.GetInt("brickcountp2");
            scoreTextP3.SetActive(false);
            brickCountTextP3.SetActive(false);
            scoreTextP4.SetActive(false);
            brickCountTextP4.SetActive(false);
        } else if (PlayerPrefs.GetInt("playercount") == 3) {
            scoreTextP1.gameObject.GetComponent<Text>().text = "P1 - " + PlayerPrefs.GetInt("scorep1");
            brickCountTextP1.gameObject.GetComponent<Text>().text = "" + PlayerPrefs.GetInt("brickcountp1");
            scoreTextP2.gameObject.GetComponent<Text>().text = "P2 - " + PlayerPrefs.GetInt("scorep2");
            brickCountTextP2.gameObject.GetComponent<Text>().text = "" + PlayerPrefs.GetInt("brickcountp2");
            scoreTextP3.gameObject.GetComponent<Text>().text = "P3 - " + PlayerPrefs.GetInt("scorep3");
            brickCountTextP3.gameObject.GetComponent<Text>().text = "" + PlayerPrefs.GetInt("brickcountp3");
            scoreTextP4.SetActive(false);
            brickCountTextP4.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("playercount") == 4) {
            scoreTextP1.gameObject.GetComponent<Text>().text = "P1 - " + PlayerPrefs.GetInt("scorep1");
            brickCountTextP1.gameObject.GetComponent<Text>().text = "" + PlayerPrefs.GetInt("brickcountp1");
            scoreTextP2.gameObject.GetComponent<Text>().text = "P2 - " + PlayerPrefs.GetInt("scorep2");
            brickCountTextP2.gameObject.GetComponent<Text>().text = "" + PlayerPrefs.GetInt("brickcountp2");
            scoreTextP3.gameObject.GetComponent<Text>().text = "P3 - " + PlayerPrefs.GetInt("scorep3");
            brickCountTextP3.gameObject.GetComponent<Text>().text = "" + PlayerPrefs.GetInt("brickcountp3");
            scoreTextP4.gameObject.GetComponent<Text>().text = "P4 - " + PlayerPrefs.GetInt("scorep4");
            brickCountTextP4.gameObject.GetComponent<Text>().text = "" + PlayerPrefs.GetInt("brickcountp4");
        }
        if (PlayerPrefs.GetString("mode") == "ModeArcade") {
            if (PlayerPrefs.GetInt("scorep1") > PlayerPrefs.GetInt("arcadehighscore")) setNewRecord("arcadehighscore", PlayerPrefs.GetInt("scorep1"), isNewHighScore);
            if (PlayerPrefs.GetInt("scorep2") > PlayerPrefs.GetInt("arcadehighscore")) setNewRecord("arcadehighscore", PlayerPrefs.GetInt("scorep2"), isNewHighScore);
            if (PlayerPrefs.GetInt("scorep3") > PlayerPrefs.GetInt("arcadehighscore")) setNewRecord("arcadehighscore", PlayerPrefs.GetInt("scorep3"), isNewHighScore);
            if (PlayerPrefs.GetInt("scorep4") > PlayerPrefs.GetInt("arcadehighscore")) setNewRecord("arcadehighscore", PlayerPrefs.GetInt("scorep4"), isNewHighScore);
            if (PlayerPrefs.GetInt("brickcountp1") > PlayerPrefs.GetInt("arcadehighcount")) setNewRecord("arcadehighcount", PlayerPrefs.GetInt("brickcountp1"), isNewHighCount);
            if (PlayerPrefs.GetInt("brickcountp2") > PlayerPrefs.GetInt("arcadehighcount")) setNewRecord("arcadehighcount", PlayerPrefs.GetInt("brickcountp2"), isNewHighCount);
            if (PlayerPrefs.GetInt("brickcountp3") > PlayerPrefs.GetInt("arcadehighcount")) setNewRecord("arcadehighcount", PlayerPrefs.GetInt("brickcountp3"), isNewHighCount);
            if (PlayerPrefs.GetInt("brickcountp4") > PlayerPrefs.GetInt("arcadehighcount")) setNewRecord("arcadehighcount", PlayerPrefs.GetInt("brickcountp4"), isNewHighCount);

            highScoreText.gameObject.GetComponent<Text>().text = "High-Score: " + PlayerPrefs.GetInt("arcadehighscore") + "  -  " + PlayerPrefs.GetInt("arcadehighcount");
        }
        else if (PlayerPrefs.GetString("mode") == "ModeTower") {
            if (PlayerPrefs.GetInt("scorep1") > PlayerPrefs.GetInt("towerhighscore")) setNewRecord("towerhighscore", PlayerPrefs.GetInt("scorep1"), isNewHighScore);
            if (PlayerPrefs.GetInt("scorep2") > PlayerPrefs.GetInt("towerhighscore")) setNewRecord("towerhighscore", PlayerPrefs.GetInt("scorep2"), isNewHighScore);
            if (PlayerPrefs.GetInt("scorep3") > PlayerPrefs.GetInt("towerhighscore")) setNewRecord("towerhighscore", PlayerPrefs.GetInt("scorep3"), isNewHighScore);
            if (PlayerPrefs.GetInt("scorep4") > PlayerPrefs.GetInt("towerhighscore")) setNewRecord("towerhighscore", PlayerPrefs.GetInt("scorep4"), isNewHighScore);
            if (PlayerPrefs.GetInt("brickcountp1") > PlayerPrefs.GetInt("towerhighcount")) setNewRecord("towerhighcount", PlayerPrefs.GetInt("brickcountp1"), isNewHighCount);
            if (PlayerPrefs.GetInt("brickcountp2") > PlayerPrefs.GetInt("towerhighcount")) setNewRecord("towerhighcount", PlayerPrefs.GetInt("brickcountp2"), isNewHighCount);
            if (PlayerPrefs.GetInt("brickcountp3") > PlayerPrefs.GetInt("towerhighcount")) setNewRecord("towerhighcount", PlayerPrefs.GetInt("brickcountp3"), isNewHighCount);
            if (PlayerPrefs.GetInt("brickcountp4") > PlayerPrefs.GetInt("towerhighcount")) setNewRecord("towerhighcount", PlayerPrefs.GetInt("brickcountp4"), isNewHighCount);

            highScoreText.gameObject.GetComponent<Text>().text = "High-Score: " + PlayerPrefs.GetInt("towerhighscore") + "  -  " + PlayerPrefs.GetInt("towerhighcount");
        }
        if (!isNewHighScore && !isNewHighCount) highScoreIndicator.SetActive(false);
    }

    void Start() {
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
    }

    void setNewRecord(string prefKey, int newScore, bool indicator) {
        indicator = true;
        PlayerPrefs.SetInt(prefKey, newScore);
    }
}
