using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColor : MonoBehaviour
{
    public Color32 normalColor;
    public Color32 pressedColor;


    public void PressedColor(Text txt)
    {
        txt.color = pressedColor;
    }

    public void NormalColor(Text txt)
    {
        txt.color = normalColor;
    }
}
