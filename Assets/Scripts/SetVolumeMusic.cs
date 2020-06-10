using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolumeMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("FirstTime") == 0)
        {
            PlayerPrefs.SetFloat("volume", 0.5f);
            gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
            PlayerPrefs.SetInt("FirstTime", 1);
        }
        else
        {
            gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
        }
    }
}
