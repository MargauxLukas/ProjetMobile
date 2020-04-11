using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    public Text text;
    public ThumbnailManager tm;

    public void Cut()
    {
        tm.CheckAction(3);
    }

    public void Knead()
    {
        tm.CheckAction(2);
    }

    public void Whip()
    {
        tm.CheckAction(1);
    }

    public void Eat()
    {
        /*Debug.Log("Eat");

        //Proto 1
        text.text += "NOM\n";*/

        //Proto 2

    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }
}
