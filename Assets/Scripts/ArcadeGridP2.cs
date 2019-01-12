using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeGridP2 : MonoBehaviour
{
    public static int gridP2Width = 10;
    public static int gridP2Height = 20;
    public static Transform[,] gridP2 = new Transform[gridP2Width, gridP2Height];
    public GameObject[] bricks;
    public GameObject player;
    public bool isGameOver = false;
    private int[] rng;
    private int rngIndex = 0;

    void Start() {
        rng = FindObjectOfType<UtilityRNG>().randomNumbers.ToArray();
        instantiateNextBrick();
    }

    void Update() {
        if (isGameOver)
            for (int y = 0; y < gridP2Height; y++)
                for (int x = 0; x < gridP2Width; x++)
                    if (gridP2[x, y] != null) gridP2[x, y].gameObject.GetComponent<MeshRenderer>().material = player.GetComponent<PlayerInit>().charMaterial;
    }

    // check if a brick is within the grid's boundaries
    public bool isInsideGrid(Vector2 pos) {
        return ((int)pos.x >= 0 && (int)pos.x < gridP2Width && (int)pos.y >= 0);
    }

    // update the grid's bricks: new bricks are always resetted until they land --> become part of the grid
    public void updateGrid(GameObject brick) {
        for (int y = 0; y < gridP2Height; y++)                                           // check every row                                    
            for (int x = 0; x < gridP2Width; x++)                                        // and every column
                if (gridP2[x, y] != null && gridP2[x, y].parent == brick.transform)      // check if there is a brick
                    gridP2[x, y] = null;                                                 // act like it's not there
        foreach (Transform cube in brick.transform) {
            Vector2 pos = new Vector2(Mathf.Round(cube.position.x), Mathf.Round(cube.position.y));
            if (pos.y < gridP2Height) gridP2[(int)pos.x, (int)pos.y] = cube;             // place a brick into the grid
        }
    }

    // return a transform in the grid at a certain position; used for checking valid moves
    public Transform getTransformAtGridPosition(Vector2 pos) {
        if (pos.y > gridP2Height - 1) return null;
        else return gridP2[(int)pos.x, (int)pos.y];
    }

    // everytime a brick lands, check if the row is full and if it is, clear it and adjust the others
    public void updateRows() {
        for (int y = 0; y < gridP2Height; y++) {
            if (isRowFullAtY(y)) {
                PlayerPrefs.SetInt("scorep2", PlayerPrefs.GetInt("scorep2") + 50 * y);   // give points: the higher the row was, the more points it is worth
                deleteRowAtY(y);
                moveRowsDown(y + 1);
                y--;
            }
        }
    }

    public bool isRowFullAtY(int y) {
        for (int x = 0; x < gridP2Width; x++) if (gridP2[x, y] == null) return false;
        return true;
    }

    public void deleteRowAtY(int y) {
        for (int x = 0; x < gridP2Width; x++) {
            Destroy(gridP2[x, y].gameObject);
            gridP2[x, y] = null;
        }
    }

    public void moveRowsDown(int y) {
        for (int i = y; i < gridP2Height; i++) moveRowDown(i);
    }

    public void moveRowDown(int y) {
        for (int x = 0; x < gridP2Width; x++) {
            if (gridP2[x, y] != null) {
                gridP2[x, y - 1] = gridP2[x, y];
                gridP2[x, y] = null;
                gridP2[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    // check the highest row for cubes
    public void checkGameOver(GameObject brick) {
        for (int x = 0; x < gridP2Width; x++) {
            foreach (Transform cube in brick.transform) {
                Vector2 pos = new Vector2((int)Mathf.Round(cube.position.x), (int)Mathf.Round(cube.position.y));
                if (pos.y > gridP2Height - 1) {
                    isGameOver = true;
                    break;
                }
            }
        }
    }

    public void instantiateNextBrick() {
        int random = rng[rngIndex];
        GameObject nextBrick = (GameObject)Instantiate(bricks[random], player.transform);
        nextBrick.transform.position += new Vector3(5, 20, 0);
        if (rngIndex == 63) rngIndex = 0; else rngIndex++;
    }
}
