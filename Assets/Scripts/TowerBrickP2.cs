using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBrickP2 : MonoBehaviour
{
    public bool isRotationAllowed = true;
    public bool isRotationLimited = false;
    public float moveVal = 0.25f;
    public float rotateVal = 90;
    public bool released = false;

    void Awake() {
        string player = this.gameObject.transform.parent.name;
        if (!player.EndsWith("2")) Destroy(this);
    }

    void Update() {
        if (FindObjectOfType<TowerPlatformP2>().isGameOver) Destroy(this.gameObject);
        checkInput();
    }

    void checkInput() {
        if (Input.GetKeyDown(KeyCode.J) && isValidMove(-moveVal, 0)) move(-moveVal, 0);
        if (Input.GetKeyDown(KeyCode.L) && isValidMove(moveVal, 0)) move(moveVal, 0);
        if (isRotationAllowed && Input.GetKeyDown(KeyCode.I)) rotate(rotateVal);
        if (Input.GetKeyDown(KeyCode.K) && isValidMove(0, -moveVal)) move(0, -moveVal);
        if (Input.GetKeyDown(KeyCode.U) && isNotInSpawn()) release();
    }

    void move(float x, float y) => this.gameObject.transform.position += new Vector3(x, y, 0);

    void rotate(float z) {
        if (isRotationLimited && this.gameObject.transform.rotation.eulerAngles.z >= rotateVal) this.gameObject.transform.Rotate(0, 0, -z);
        else this.gameObject.transform.Rotate(0, 0, z);
    }

    void release() {
        PlayerPrefs.SetInt("scorep2", PlayerPrefs.GetInt("scorep2") + 10 + (int)this.gameObject.transform.position.y);
        PlayerPrefs.SetInt("brickcountp2", PlayerPrefs.GetInt("brickcountp2") + 1);
        this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        FindObjectOfType<TowerPlatformP2>().instantiateNextBrick();
        released = true;
        enabled = false;
    }

    bool isValidMove(float x, float y) {
        Vector3 pos = this.gameObject.transform.position + new Vector3(x, y, 0);
        if (FindObjectOfType<TowerPlatformP2>().isInsideBounds(pos)) return true;
        return false;
    }

    bool isNotInSpawn() {
        if (this.gameObject.transform.position.y > 33 && this.gameObject.transform.position.x < 14 && this.gameObject.transform.position.x > 6) return false;
        return true;
    }
}
