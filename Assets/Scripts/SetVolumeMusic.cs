﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolumeMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
    }
}
