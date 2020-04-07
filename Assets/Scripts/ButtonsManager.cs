using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    public Text text;
    public ThumnailManager tm;

    public void Cut()
    {
        /*Debug.Log("Cut");

        //Proto 1
        text.text += "THUD\n" ;*/

        //Proto 2
        tm.CheckAction(3);

    }

    public void Knead()
    {
        /*Debug.Log("Knead");

        //Proto 1
        text.text += "SQUIRT\n";*/

        //Proto 2
        tm.CheckAction(2);
    }

    public void Whip()
    {
       /* Debug.Log("Whip");

        //Proto 1
        text.text += "SWOOSH\n";*/

        //Proto 2
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
