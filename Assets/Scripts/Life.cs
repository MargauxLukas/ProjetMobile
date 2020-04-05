﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public int nbIconMax = 20;
    public int nbIconCurrent = 20;

    public float nb;

    public void Update()
    {
        nb = 1 / (float)nbIconMax;
        GetComponent<Image>().fillAmount = nb * nbIconCurrent; 
    }
}
