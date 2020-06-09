using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllTexts : MonoBehaviour
{
    public static AllTexts instance;
    public List<Text> textList;

    public void Awake()
    {
        instance = this;    
    }

    public void Start()
    {
        SetStarsNoob();
    }

    public void SetStarsEasy()
    {
        for (int i = 1; i < textList.Count; i++)
        {
            textList[i-1].text = PlayerPrefs.GetInt("starLevel" + i + "Easy").ToString();
        }
    }
    public void SetStarsMedium()
    {
        for (int i = 1; i < textList.Count; i++)
        {
            textList[i-1].text = PlayerPrefs.GetInt("starLevel" + i + "Medium").ToString();
        }
    }

    public void SetStarsHard()
    {
        for (int i = 1; i < textList.Count; i++)
        {
            textList[i-1].text = PlayerPrefs.GetInt("starLevel" + i + "Hard").ToString();
        }
    }

    public void SetStarsNoob()
    {
        for (int i = 1; i < textList.Count; i++)
        {
            textList[i-1].text = PlayerPrefs.GetInt("starLevel" + i + "Noob").ToString();
        }
    }
}
