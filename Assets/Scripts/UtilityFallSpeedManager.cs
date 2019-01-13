using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityFallSpeedManager : MonoBehaviour
{
    public float fallSpeed = 1;
    public float minSpeed = 0.25f;
    public int increaseTime = 1000;
    private int timer = 0;

    void Update() {
        if (timer > increaseTime) {
            if (fallSpeed > minSpeed) {
                fallSpeed -= 0.025f;
                timer = 0;
            }
            else enabled = false;
        }
        timer++;
    }
}
