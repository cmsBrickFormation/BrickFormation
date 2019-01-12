using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlatform : MonoBehaviour
{
    public static int gridWidth = 10;
    public static int gridHeight = 20;
    public static Transform[,] grid = new Transform[gridWidth, gridHeight];

    // check if a brick is within the grid's boundaries
    public bool isInsideGrid(Vector2 pos) {
        return ((int)pos.x >= 0 && (int)pos.x < gridWidth && (int)pos.y >= 0);
    }

    // update the grid's bricks: new bricks are always resetted until they land --> become part of the grid
    public void updateGrid(GameObject brick) {
        for (int y = 0; y < gridHeight; y++)                                        // check every row                                    
            for (int x = 0; x < gridWidth; x++)                                     // and every column
                if (grid[x, y] != null && grid[x, y].parent == brick.transform)     // check if there is a brick
                    grid[x, y] = null;                                              // act like it's not there
        foreach (Transform cube in brick.transform) {
            Vector2 pos = new Vector2(Mathf.Round(cube.position.x), Mathf.Round(cube.position.y));
            if (pos.y < gridHeight) grid[(int)pos.x, (int)pos.y] = cube;               // place a brick into the grid
        }
    }

    // return a transform in the grid at a certain position; used for checking valid moves
    public Transform getTransformAtGridPosition(Vector3 pos) {
        if (pos.y > gridHeight - 1) return null;
        else return grid[(int)pos.x, (int)pos.y];
    }

    // everytime a brick lands, check if the row is full and if it is, clear it and adjust the others
    public void updateRows() {
        for (int y = 0; y < gridHeight; y++) {
            if (isRowFullAtY(y)) {
                deleteRowAtY(y);
                moveRowsDown(y + 1);
                y--;
            }
        }
    }

    public bool isRowFullAtY(int y) {
        for (int x = 0; x < gridWidth; x++) if (grid[x, y] == null) return false;
        return true;
    }

    public void deleteRowAtY(int y) {
        for (int x = 0; x < gridWidth; x++) {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    public void moveRowsDown(int y) {
        for (int i = y; i < gridHeight; i++) moveRowDown(i);
    }

    public void moveRowDown(int y) {
        for (int x = 0; x < gridWidth; x++) {
            if (grid[x, y] != null) {
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;
                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    // check the highest row for cubes
    public void checkGameOver(GameObject brick) {
        for (int x = 0; x < gridWidth; x++) {
            foreach (Transform cube in brick.transform) {
                Vector2 pos = new Vector2((int)Mathf.Round(cube.position.x), (int)Mathf.Round(cube.position.y));
                if (pos.y > gridHeight - 1) {
                    PlayerPrefs.SetInt("gameover", 1);
                    break;
                }
            }
        }
    }
}
