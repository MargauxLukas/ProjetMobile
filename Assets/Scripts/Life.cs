﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public int lifeMax = 10;
    public int currentLife = 10;

    public float nb;
    public bool stuned = false;

    public void Update()
    {
        nb = 1 / (float)lifeMax;
        if (!stuned)
        {
            GetComponent<Image>().fillAmount = nb * currentLife;

            if (currentLife == 0)
            {
                stuned = true;
                ThumbnailManager.instance.phase1 = false;
                LevelManager.instance.ActivatePhase2();
                ThumbnailManager.instance.ChooseThumbnail();
            }
        }
        else
        {
            GetComponent<Image>().fillAmount += 0.005f;
        }
    }
}
