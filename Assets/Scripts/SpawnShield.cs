using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShield : MonoBehaviour
{
    public GameObject prefab;

    public void ShieldInstance(int numShield)
    {
        Vector3 center = transform.position;
        for (int i = 0; i < numShield; i++)
        {
            int a = i * 360/numShield;
            Vector3 pos = RandomCircle(new Vector3(0f, 0.5f, -2f),0.3f, a);
            Quaternion rot = Quaternion.identity;
            Instantiate(prefab, pos, rot, transform);
        }
    }

    Vector3 RandomCircle(Vector3 center, float radius, int a)
    {
        float ang = a;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
}
