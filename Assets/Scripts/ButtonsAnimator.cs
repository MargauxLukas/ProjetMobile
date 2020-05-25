using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsAnimator : MonoBehaviour
{
    public Sprite idleSprite;
    public Sprite pressedSprite;

    public void PressedSprite()
    {
        gameObject.GetComponent<Image>().sprite = pressedSprite;
    }

    public void IdleSprite()
    {
        gameObject.GetComponent<Image>().sprite = idleSprite;
    }
}
