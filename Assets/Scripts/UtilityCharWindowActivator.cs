using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityCharWindowActivator : MonoBehaviour
{
    public GameObject charWindow2, charWindow3, charWindow4;

    void Start() => deactivateAll();

    void Update() {
        if (PlayerPrefs.GetInt("playercount") == 0) deactivateAll();
        if (PlayerPrefs.GetInt("playercount") == 1) charWindow2.SetActive(true);
        if (PlayerPrefs.GetInt("playercount") == 2) { charWindow2.SetActive(true); charWindow3.SetActive(true); }
        if (PlayerPrefs.GetInt("playercount") == 3) { charWindow2.SetActive(true); charWindow3.SetActive(true); charWindow4.SetActive(true); }
    }

    private void deactivateAll() {
        charWindow2.SetActive(false);
        charWindow3.SetActive(false);
        charWindow4.SetActive(false);
    }
}
