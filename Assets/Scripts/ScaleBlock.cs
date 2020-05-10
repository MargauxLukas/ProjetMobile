using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBlock : MonoBehaviour
{
    void Update()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
