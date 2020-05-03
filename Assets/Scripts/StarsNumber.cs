using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsNumber : MonoBehaviour
{
    public string keyLevel;

    void Start()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt(keyLevel).ToString();
    }
}
