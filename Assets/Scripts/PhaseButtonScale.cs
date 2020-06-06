using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseButtonScale : MonoBehaviour
{
    public GameObject bottomScreen;
    public float bottomScreenHeight;
    public float top;
    public float bottom;

    public void ScaleButtons()
    {
        bottomScreenHeight = bottomScreen.GetComponent<RectTransform>().offsetMax.y;
        top = bottomScreenHeight * 0.13f;
        bottom = bottomScreenHeight * 0.32f;

        GetComponent<RectTransform>().offsetMax = new Vector2(GetComponent<RectTransform>().offsetMax.x, top);
        GetComponent<RectTransform>().offsetMin = new Vector2(GetComponent<RectTransform>().offsetMin.x, -bottom);
    }
}
