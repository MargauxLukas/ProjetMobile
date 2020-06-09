using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VFXvolumeSame : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat("volumeVFX");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("volumeVFX", gameObject.GetComponent<Slider>().value);
    }
}
