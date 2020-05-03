using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipDelete : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, GetComponent<AudioSource>().clip.length);
    }
}
