﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovePhase1 : MonoBehaviour
{
    public Vector2 posInit;
    public Vector2 posTarget;

    public bool needMove = false;

    public void Start()
    {
        posInit = transform.position;
        posTarget.y = posInit.y;
    }

    public void Update()
    {
        if(needMove && ThumbnailManager.instance.phase1)
        {
            transform.position = Vector3.MoveTowards(transform.position, posInit, 30f);

            if (Vector3.Distance(transform.position, posInit) < 0.001f)
            {
                needMove = false;
            }
        }
        else if(needMove && !ThumbnailManager.instance.phase1)
        {
            transform.position = Vector3.MoveTowards(transform.position, posTarget, 30f);

            if (Vector3.Distance(transform.position, posTarget) < 0.001f)
            {
                needMove = false;
            }
        }
    }

}
