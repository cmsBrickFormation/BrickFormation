using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlatformP2 : MonoBehaviour
{
    public static int platformP2Width = 20;
    public GameObject[] bricks;
    public GameObject player;
    public GameObject livesText;
    public bool isGameOver = false;
    private int[] rng;
    private int rngIndex = 0;
    private List<GameObject> instantiatedBricks = new List<GameObject>();

    void Start() {
        rng = FindObjectOfType<UtilityRNG>().randomNumbers.ToArray();
        instantiateNextBrick();
    }

    void Update() {
        if (PlayerPrefs.GetFloat("livesp2") <= 0 || PlayerPrefs.GetInt("winnerp2") == 1) isGameOver = true;
        if (isGameOver) {
            Destroy(FindObjectOfType<UtilityBrickPreviewP2>().gameObject);
            Destroy(livesText);
            foreach (GameObject brick in instantiatedBricks) {
                brick.GetComponent<Rigidbody>().useGravity = false;
                Transform[] cubes = brick.GetComponentsInChildren<Transform>();
                for (int i = 1; i < cubes.Length; i++) cubes[i].gameObject.GetComponent<MeshRenderer>().material = player.GetComponent<PlayerInit>().charMaterial;
            }
            enabled = false;
        }
    }

    // check if a brick is within boundaries
    public bool isInsideBounds(Vector3 pos) {
        return (pos.x >= 0 && pos.x < platformP2Width && pos.y >= 5);
    }

    public void instantiateNextBrick() {
        int random = rng[rngIndex];
        GameObject nextBrick = (GameObject)Instantiate(bricks[random], player.transform);
        nextBrick.transform.position += new Vector3(10, 35, 0);
        instantiatedBricks.Add(nextBrick);
        if (rngIndex == 63) rngIndex = 0; else rngIndex++;
        FindObjectOfType<UtilityBrickPreviewP2>().updateBrickPreview(rngIndex);
    }
}
