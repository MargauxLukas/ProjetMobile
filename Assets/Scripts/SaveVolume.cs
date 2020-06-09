using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveVolume : MonoBehaviour
{
    
    void Start()
    {
        gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat("volume");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("volume", gameObject.GetComponent<Slider>().value);
    }
}
