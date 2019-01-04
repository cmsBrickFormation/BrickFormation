using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorBrick : MonoBehaviour
{
    public bool isRotationAllowed = true;
    public bool isRotationLimited = false;
    public int moveVal = 1;
    public int rotateVal = 90;
    public float fallSpeed = 1;
    private float fallTime = 0;

    void Update() {
        checkInput();
        fallDown();
    }

    void checkInput() {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && isValidMove(-moveVal, 0, 0)) move(-moveVal);
        if (Input.GetKeyDown(KeyCode.RightArrow) && isValidMove(moveVal, 0, 0)) move(moveVal);
        if (isRotationAllowed && Input.GetKeyDown(KeyCode.UpArrow) && isValidMove(0, 0, rotateVal)) rotate(rotateVal);
    }

    void fallDown() {
        if (Time.time - fallTime >= fallSpeed && isValidMove(0, -moveVal, 0)) {
            this.gameObject.transform.position += new Vector3(0, -moveVal, 0);
            fallTime = Time.time;
        }
    }

    void move(float x) {
        this.gameObject.transform.position += new Vector3(x, 0, 0);
    }

    void rotate(float z) {
        if (isRotationLimited && this.gameObject.transform.rotation.eulerAngles.z >= rotateVal) this.gameObject.transform.Rotate(0, 0, -z);
        else this.gameObject.transform.Rotate(0, 0, z);
    }

    bool isValidMove(float moveX, float moveY, float rotateZ) {
        bool isValid = true;
        Quaternion currentRotation = this.gameObject.transform.rotation;                                    // save current rotation
        rotate(rotateZ);                                                                                    // rotate the brick into its next form
        foreach (Transform cube in this.gameObject.transform) {
            Vector3 attemptedPos = cube.position + new Vector3(moveX, moveY, 0);                            // move each cube of the brick into their next position
            if (FindObjectOfType<BehaviorGrid>().isInsideGrid(attemptedPos) == false) isValid = false;      // if they are out of bounds, mark the move invalid
        }
        this.gameObject.transform.rotation = currentRotation;                                               // reset the rotation
        return isValid;
    }
}
