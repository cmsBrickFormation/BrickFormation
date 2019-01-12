using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeBrickP3 : MonoBehaviour
{
    public bool isRotationAllowed = true;
    public bool isRotationLimited = false;
    public int moveVal = 1;
    public int rotateVal = 90;
    public float fallSpeed = 1;
    private float fallTime = 0;

    void Awake() {
        string player = this.gameObject.transform.parent.name;
        if (!player.EndsWith("3")) Destroy(this);
    }

    void Update() {
        checkInput();
        fallDown();
    }

    void checkInput() {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && isValidMove(-moveVal, 0, 0)) move(-moveVal, 0);
        if (Input.GetKeyDown(KeyCode.RightArrow) && isValidMove(moveVal, 0, 0)) move(moveVal, 0);
        if (isRotationAllowed && Input.GetKeyDown(KeyCode.UpArrow) && isValidMove(0, 0, rotateVal)) rotate(rotateVal, true);
    }

    void fallDown() {
        if (Time.time - fallTime >= fallSpeed) {
            if (isValidMove(0, -moveVal, 0)) {
                move(0, -moveVal);
                fallTime = Time.time;
            } else {
                enabled = false;
                FindObjectOfType<ArcadeGridP3>().updateRows();
                FindObjectOfType<ArcadeGridP3>().checkGameOver(this.gameObject);
                if (!FindObjectOfType<ArcadeGridP3>().isGameOver) FindObjectOfType<ArcadeGridP3>().instantiateNextBrick();
                else Destroy(this.gameObject);
            }
        }
    }

    void move(int x, int y) {
        this.gameObject.transform.position += new Vector3(x, y, 0);
        FindObjectOfType<ArcadeGridP3>().updateGrid(this.gameObject);
    }

    void rotate(int z, bool isActuallyARotation) {
        if (isRotationLimited && this.gameObject.transform.rotation.eulerAngles.z >= rotateVal) this.gameObject.transform.Rotate(0, 0, -z);
        else this.gameObject.transform.Rotate(0, 0, z);
        if (isActuallyARotation) FindObjectOfType<ArcadeGridP3>().updateGrid(this.gameObject);                                                  // this is needed because the brick is also rotated when validating a move
    }

    bool isValidMove(int moveX, int moveY, int rotateZ) {
        bool isValid = true;
        Quaternion currentRotation = this.gameObject.transform.rotation;                                                                            // save current rotation
        rotate(rotateZ, false);                                                                                                                     // rotate the brick into its next form
        foreach (Transform cube in this.gameObject.transform) {
            Vector2 attemptedPos = new Vector2((int)Mathf.Round(cube.position.x + moveX), (int)Mathf.Round(cube.position.y + moveY));               // move each cube of the brick into their next position
            if (FindObjectOfType<ArcadeGridP3>().isInsideGrid(attemptedPos) == false) isValid = false;                                              // if a cube is out of bounds then the move is invalid
            else if (FindObjectOfType<ArcadeGridP3>().getTransformAtGridPosition(attemptedPos) != null)                                             // also, if it's in bounds but there is already a brick on that spot
                if (FindObjectOfType<ArcadeGridP3>().getTransformAtGridPosition(attemptedPos).parent != this.gameObject.transform) isValid = false; // and if that brick is not the one we want to move, then the move is also invalid
        }
        this.gameObject.transform.rotation = currentRotation;                                                                                       // reset the rotation
        return isValid;
    }
}
