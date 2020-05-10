using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopScale : MonoBehaviour
{
    public float bottomScreenHeight;
    public float top;
    void Start()
    {
        bottomScreenHeight = transform.parent.parent.parent.GetChild(0).GetComponent<RectTransform>().offsetMax.y;
        top = bottomScreenHeight * 0.85f;
        gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(gameObject.GetComponent<RectTransform>().offsetMax.x, top);
    }
}
