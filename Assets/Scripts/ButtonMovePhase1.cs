using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovePhase1 : MonoBehaviour
{
    private Vector2  posInit;
    private Vector2 posTarget;

    public bool needMove = false;

    public void Start()
    {
        posInit     = transform.position;
        posTarget.y = posInit.y;

        if (gameObject.name.Contains("Defend"))
        {
            posTarget.x = posInit.x - Screen.width/1.6f;
        }
        else
        {
            posTarget.x = posInit.x + Screen.width/1.6f;
        }

    }

    public void Update()
    {
        if(needMove && ThumbnailManager.instance.phase1)                                                                                               //Si on est en Phase 1, le bouton reprend sa place initial.
        {
            transform.position = Vector3.MoveTowards(transform.position, posInit, 70f);

            if (Vector3.Distance(transform.position, posInit) < 0.001f)
            {
                needMove = false;

                if (LevelManager.instance.isInfinite)
                {
                    LevelManager.instance.DesactivateAllButtons();
                    LevelManager.instance.ActivateGoodButtons();
                }
            }
        }
        else if(needMove && !ThumbnailManager.instance.phase1)                                                                                         //Si on est en Phase 2, le bouton prend la place "target".
        {
            transform.position = Vector3.MoveTowards(transform.position, posTarget, 70f);

            if (Vector3.Distance(transform.position, posTarget) < 0.001f)
            {
                needMove = false;
            }
        }
    }
}
