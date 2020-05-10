using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapisPosition : MonoBehaviour
{
    public GameObject bottomScreen;
    public float screenWidth;
    public float screendW2;
    public float screenWnegativ;
    public float screenWmultipliate;
    public float ok;

    void Start()
    {
        screenWidth = Screen.width;
        screendW2 = Screen.width / 2;
        screenWnegativ = -(Screen.width / 2);
        screenWmultipliate = -(Screen.width / 2) * 0.001f;
        ok = -(720f / 2f) * 0.001f;

        transform.position = new Vector2(-(Screen.currentResolution.width/2f) * 0.001f , transform.position.y);
    }
}
