using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    void Update()
    {
        transform.RotateAround(new Vector3(0f, 0.5f, -2f), new Vector3(0f, 1.5f, 0f), 3f);
        transform.rotation = Quaternion.identity;

        transform.localScale = new Vector3((transform.position.z*0.01f) / -2.1f, (transform.position.z*0.01f) / -2.1f, 0f);
    }
}
