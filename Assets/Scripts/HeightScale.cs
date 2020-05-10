﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightScale : MonoBehaviour
{
    public float bottomScreenHeight;
    void Update()
    {
        bottomScreenHeight = transform.parent.parent.GetChild(0).GetComponent<RectTransform>().offsetMax.y;
        gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(gameObject.GetComponent<RectTransform>().offsetMin.x, bottomScreenHeight);
    }
}
