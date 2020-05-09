using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomButtonsScale : MonoBehaviour
{
    public GameObject bottomScreen;
    public float bottomScreenHeight;
    public float top;

    public void ScaleButtons()
    {
        bottomScreenHeight = bottomScreen.GetComponent<RectTransform>().offsetMax.y;
        top = bottomScreenHeight - (bottomScreenHeight * 0.32f);

        GetComponent<RectTransform>().offsetMax = new Vector2(GetComponent<RectTransform>().offsetMax.x, top);
    }
}
