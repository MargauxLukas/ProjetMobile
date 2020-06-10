using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolumeSFX : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("FirstTimeVFX") == 0)
        {
            PlayerPrefs.SetFloat("volumeVFX", 0.5f);
            gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volumeVFX");
            PlayerPrefs.SetInt("FirstTimeVFX", 1);
        }
        else
        {
            gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volumeVFX");
        }
    }
}
