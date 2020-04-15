using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thumbnail : MonoBehaviour
{
    public Vector3 target;
    public bool move = false;
    public bool validate = false;
    public bool needToMaintain = false;
    public bool isLocked = false;

    public void Update()
    {
        if(move)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 5f);

            if(Vector3.Distance(transform.position, target) < 0.5f)
            {
                move = false;
            }
        }
        else if(validate)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 20f);
            transform.Rotate(new Vector3(0f, 0f, -40f));

            if (Vector3.Distance(transform.position, target) < 200f)
            {
                validate = false;
                Destroy(gameObject);
            }
        }
    }

    public void NeedToMove(Vector3 pos)
    {
        target = pos;
        move = true;
    }

    public void NeedToDestroy()
    {
        target.x = -382f;
        target.y = 2000f;
        move = false;
        validate = true;
    }
}
