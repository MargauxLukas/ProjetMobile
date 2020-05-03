using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryStars : MonoBehaviour
{
    private Color32 gold = new Color32(250, 184, 58, 255);

    public GameObject star2;
    public GameObject star3;
    public int nbStars = 0;

    public void SetStars(float life)
    {
        nbStars = 1;
        if(life > 0.3333)
        {
            nbStars = 2;
            star2.GetComponent<Image>().color = gold;
        }
        if(life > 0.6666)
        {
            nbStars = 3;
            star3.GetComponent<Image>().color = gold;
        }
    }
}
