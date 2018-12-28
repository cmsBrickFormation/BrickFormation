using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashscreenControlTeam : MonoBehaviour
{
    public GameObject logo;
    public float sceneDuration = 180;
    public string nextScene = "MainMenu";

    private float timer = 0;

    void Update()
    {
        moveLogo(logo);
        timer++;
        if (timer > sceneDuration) SceneManager.LoadScene(nextScene);
    }

    void moveLogo(GameObject logo)
    {
        if (timer < 140) logo.GetComponent<RectTransform>().anchoredPosition = new Vector2(logo.GetComponent<RectTransform>().anchoredPosition.x, logo.GetComponent<RectTransform>().anchoredPosition.y - 5);
    }
}
