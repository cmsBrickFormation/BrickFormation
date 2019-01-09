using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorGrid : MonoBehaviour
{
    public static int gridWidth = 10;
    public static int gridHeight = 20;
    public static Transform[,] grid = new Transform[gridWidth, gridHeight];

    // update the grid's bricks: new bricks are always resetted until they land --> become part of the grid
    public void updateGrid(GameObject brick) {
        for (int y = 0; y < gridHeight; ++y)                                        // check every row                                    
            for (int x = 0; x < gridWidth; ++x)                                     // and every column
                if (grid[x, y] != null && grid[x, y].parent == brick.transform)     // check if there is a brick
                    grid[x, y] = null;                                              // act like it's not there
        foreach (Transform b in brick.transform) {
            Vector2 pos = new Vector2(Mathf.Round(b.position.x), Mathf.Round(b.position.y));
            if (pos.y < gridHeight) grid[(int)pos.x, (int)pos.y] = b;               // place a brick into the grid
        }
    }

    // check if a brick is within the grid's boundaries
    public bool isInsideGrid(Vector2 pos) {
        return ((int)pos.x >= 0 && (int)pos.x < gridWidth && (int)pos.y >= 0);
    }

    // return a transform in the grid at a certain position; used for checking valid moves
    public Transform getTransformAtGridPosition(Vector3 pos) {
        if (pos.y > gridHeight - 1) return null;
        else return grid[(int)pos.x, (int)pos.y];
    }
}
