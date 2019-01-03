using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorBrick : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update() {
        checkInput();
    }

    void checkInput() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) move(-1);
        if (Input.GetKeyDown(KeyCode.RightArrow)) move(1);
        if (Input.GetKeyDown(KeyCode.UpArrow)) rotate(90);
    }

    void move(float x) {
        this.gameObject.transform.position += new Vector3(x, 0 , 0);
    }

    void rotate(float z) {
        this.gameObject.transform.Rotate(0, 0, z);
    }
}
