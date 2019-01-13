using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityBrickPreviewP3 : MonoBehaviour
{
    public GameObject[] bricks;
    private int[] rng;
    private int nextIndex;
    private bool previewNeedsChange = false;

    void Start() {
        hideBricks();
        rng = FindObjectOfType<UtilityRNG>().randomNumbers.ToArray();
    }

    void Update() {
        if (previewNeedsChange) {
            hideBricks();
            bricks[rng[nextIndex]].SetActive(true);
            previewNeedsChange = false;
        }
    }

    public void updateBrickPreview(int next) {
        if (next == 64) nextIndex = 0; else nextIndex = next;
        previewNeedsChange = true;
    }

    private void hideBricks() {
        foreach (GameObject brick in bricks) brick.SetActive(false);
    }
}
