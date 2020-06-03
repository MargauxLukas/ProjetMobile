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
    public bool isChip = false;
    public bool isFirst = false;
    public bool wantCandy = false;

    public GameObject Lock;

    public void Update()
    {   
        if(isFirst)
        {
            if (gameObject.name.Contains("CookMaintain"))
            {
                transform.GetComponent<RectTransform>().sizeDelta = new Vector2(110f, 230f);
            }
            else
            {
                transform.GetComponent<RectTransform>().sizeDelta = new Vector2(110f, 110f);
            }


            if (LevelManager.instance.level6Tuto)
            {
                if (gameObject.name.Contains("x2"))
                {
                    TutorialManager.instance.Level6SpecialCut();
                }

                if (gameObject.name.Contains("Pinch"))
                {
                    TutorialManager.instance.Level6SpecialKnead();
                }

                if (gameObject.name.Contains("Mixed"))
                {
                    TutorialManager.instance.Level6SpecialWhip();
                }
            }
            else if(LevelManager.instance.level8Tuto)
            {
                if(gameObject.name.Contains("Maintain"))
                {
                    TutorialManager.instance.Level8SpecialCook();
                }

                if(gameObject.name.Contains("Launch"))
                {
                    TutorialManager.instance.Level8SpecialBoil();
                }
            }
            else if(LevelManager.instance.level11Tuto)
            {
                if(gameObject.name.Contains("Lock"))
                {
                    TutorialManager.instance.Level11FirstLock();
                }
            }
            isFirst = false;
        }
        if(move)
        {        
            transform.position = Vector3.MoveTowards(transform.position, target, 50f);

            if(Vector3.Distance(transform.position, target) < 0.5f)
            {
                move = false;
                TapisManager.instance.SetTapisOff();

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

        TapisManager.instance.SetTapisOn();
    }

    public void NeedToDestroy()
    {
        LevelManager.instance.GoToBin(this.gameObject);
        target.x = -382f;
        target.y = 2000f;
        move = false;
        validate = true;
    }
}
