﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeBrickInstantiater : MonoBehaviour
{
    public GameObject[] bricks;

    void Start() {
        instantiateNextBrick();
    }

    public void instantiateNextBrick() {
        GameObject nextBrick = (GameObject)Instantiate(bricks[Random.Range(0, bricks.Length)], new Vector3(5, 20, 0), Quaternion.identity);
    }
}