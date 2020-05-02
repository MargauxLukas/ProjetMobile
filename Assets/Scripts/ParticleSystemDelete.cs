using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemDelete : MonoBehaviour
{
    public void Start()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();

        Destroy(transform.parent.gameObject, ps.duration + ps.startLifetime);
    }
}
