using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllerCharWindow : MonoBehaviour
{
    public GameObject charList;
    public int activeIndex = 0;
    private List<GameObject> chars = new List<GameObject>();
    private GameObject[] charArray;
    private int charsIndex = 0;

    void Start() {
        foreach (RectTransform t in charList.GetComponentsInChildren<RectTransform>()) {
            chars.Add(t.gameObject);
            charsIndex++;
        }
        charArray = chars.ToArray();
        setActive(activeIndex);
    }

    public void onPrevClick() => setActive(activeIndex - 1);
    public void onNextClick() => setActive(activeIndex + 1);

    private void setActive(int index) {
        if (index < 0) index = 3;
        else if (index > 3) index = 0;
        activeIndex = index;
        foreach (GameObject go in chars) go.SetActive(false);
        charArray[activeIndex].SetActive(true);
    }
}
