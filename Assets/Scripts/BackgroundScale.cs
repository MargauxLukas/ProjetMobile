using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScale : MonoBehaviour
{
    public float screenWidth;


    void Start()
    {
        screenWidth = Screen.width * 0.001f;
        transform.localScale = new Vector3((screenWidth*0.35f), (screenWidth * 0.35f), 1f);
    }
}
