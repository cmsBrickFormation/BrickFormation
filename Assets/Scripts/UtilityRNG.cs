using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityRNG : MonoBehaviour
{
    public List<int> randomNumbers = new List<int>();

    void Awake() => generateRandomNumbers();

    void generateRandomNumbers() {
        for (int i = 0; i < 64; i++) randomNumbers.Add(Random.Range(0, 7));
    }
}
