using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class TapisManager : MonoBehaviour
{
    public static TapisManager instance;

    public Vector2 posPhase2 = new Vector2(0f, -0.04f);
    public Vector2 posPhase1 = new Vector2(0f, -0.32f);

    public bool goToPhase1 = false;
    public bool goToPhase2 = false;

    public void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        if (goToPhase2)
        {
            transform.parent.transform.position = Vector3.MoveTowards(transform.parent.transform.position, posPhase2, 0.05f);

            if (Vector3.Distance(transform.parent.transform.position, posPhase2) < 0.001f)
            {

                goToPhase2 = false;
            }
        }
        else if( goToPhase1)
        {
            transform.parent.transform.position = Vector3.MoveTowards(transform.parent.transform.position, posPhase1, 0.05f);

            if (Vector3.Distance(transform.parent.transform.position, posPhase1) < 0.001f)
            {

                goToPhase1 = false;
            }
        }
    }

    public void SetTapisOn()
    {
        gameObject.GetComponent<Animator>().SetBool("moving", true);
    }

    public void SetTapisOff()
    {
        gameObject.GetComponent<Animator>().SetBool("moving", false);
    } 

    public void TapisOnPhase2()
    {
        goToPhase2 = true;
    }

    public void TapisOnPhase1()
    {
        goToPhase1 = true;
    }
}
