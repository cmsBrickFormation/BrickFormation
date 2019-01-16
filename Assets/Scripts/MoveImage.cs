using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveImage : MonoBehaviour
{
    public GameObject logo;
    private int spinSpeed;
    private float timer = 0;

    void Update()
    {
        moveLogo(logo);
        timer++;

    }

    void moveLogo(GameObject logo)
    {
         if (timer < 140) logo.GetComponent<RectTransform>().anchoredPosition = new Vector2(logo.GetComponent<RectTransform>().anchoredPosition.x, logo.GetComponent<RectTransform>().anchoredPosition.y - 4);

    } 
}

