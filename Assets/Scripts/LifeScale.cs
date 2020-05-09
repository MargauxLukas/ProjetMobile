using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScale : MonoBehaviour
{
    public GameObject bottomScreen;
    public float bottomScreenHeight;
    public float bottom;

    public void Scale()
    {
        bottomScreenHeight = bottomScreen.GetComponent<RectTransform>().offsetMax.y;
        bottom = bottomScreenHeight - (bottomScreenHeight * 0.15f);

        GetComponent<RectTransform>().offsetMin = new Vector2(GetComponent<RectTransform>().offsetMin.x, -bottom);
    }
}
