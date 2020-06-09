using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolumeSFX : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volumeVFX");
    }
}
