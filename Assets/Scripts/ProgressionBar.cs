using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionBar : MonoBehaviour
{
    public float levelPercent = 1f / 5f;
    public float fillAmount;

    void Start()
    {
        fillAmount = GetComponent<Image>().fillAmount;

        switch(PlayerPrefs.GetInt("level"))
        {
            case 1:
                fillAmount = 0.02f;
                break;
            case 2:
                fillAmount = levelPercent - 0.02f;
                break;
            case 3:
                fillAmount = levelPercent * 2;
                break;
            case 4:
                fillAmount = levelPercent * 3;
                break;
            case 5:
                fillAmount = levelPercent * 4;
                break;
            case 6:
                fillAmount = levelPercent * 5;
                break;
        }

        GetComponent<Image>().fillAmount = fillAmount;
    }
}
