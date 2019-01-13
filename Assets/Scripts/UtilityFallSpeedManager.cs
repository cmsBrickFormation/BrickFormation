using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityFallSpeedManager : MonoBehaviour
{
    public float fallSpeed = 1;
    public float minSpeed = 0.3f;
    public int increaseTime = 1024;
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
