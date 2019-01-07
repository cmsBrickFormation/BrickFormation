using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickInstantiater : MonoBehaviour
{
    public GameObject[] bricks;

    void Start() {
        instantiateNextBrick();
    }

    void Update() {
        
    }

    public void instantiateNextBrick() {
        GameObject nextBrick = (GameObject)Instantiate(bricks[Random.Range(0, bricks.Length)], new Vector3(5, 20, 0), Quaternion.identity);
    }
}
