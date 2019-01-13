using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeInit : MonoBehaviour
{
    void Start() => PlayerPrefs.SetInt("gameover", 0);
}
