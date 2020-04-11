using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThumbnailManager : MonoBehaviour
{
    public Life monsterLife;
    public GameManager gm;

    public List<GameObject> thumbnailsPrefab;
    public List<GameObject> thumbnailsList;

    private int random;



    // Start is called before the first frame update
    void Start()
    {
        ChooseThumbnail();
    }

    public void Update()
    {
        if (thumbnailsList[0].gameObject.name.Contains("KneadMaintain") && Input.GetMouseButton(0))
        {
            transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<RectTransform>().localPosition += Vector3.right;
        }
        else if(thumbnailsList[0].gameObject.name.Contains("KneadMaintain") && Input.GetMouseButtonUp(0))
        {
            if(transform.GetChild(0).GetChild(0).GetChild(1).transform.localPosition.x > 40f && transform.GetChild(0).GetChild(0).GetChild(1).transform.localPosition.x < 50f)
            {
                ValideAction();
            }
            else
            {
                transform.GetChild(0).GetChild(0).GetChild(1).transform.localPosition = new Vector3(-50f, transform.GetChild(0).GetChild(0).GetChild(1).transform.localPosition.y,
                                                                                                     transform.GetChild(0).GetChild(0).GetChild(1).transform.localPosition.z);
            }
        }
    }

    public void ChooseThumbnail()
    {
        for(int i = 0; i < 10; i++)
        {
            random = Random.Range(0, 5);
            thumbnailsList.Add(thumbnailsPrefab[random]);      
        }

        Instantiate(thumbnailsList[0], transform.GetChild(0).transform.position, Quaternion.identity, transform.GetChild(0));
        Instantiate(thumbnailsList[1], transform.GetChild(1).transform.position, Quaternion.identity, transform.GetChild(1));
        Instantiate(thumbnailsList[2], transform.GetChild(2).transform.position, Quaternion.identity, transform.GetChild(2));
    }

    public void CheckAction(int nbAction)
    {
        switch(nbAction)
        {
            case 1:
                if (thumbnailsList[0].gameObject.name.Contains("Whip"))
                {
                    ValideAction();
                }
                else
                {
                    WrongAction();
                }
                break;
            case 2:
                if (thumbnailsList[0].gameObject.name.Contains("Knead"))
                {
                    if (thumbnailsList[0].gameObject.name.Contains("KneadMaintain"))
                    {
                        return;
                    }
                    else
                    {
                        ValideAction();
                    }
                }
                else
                {
                    WrongAction();
                }
                break;
            case 3:
                if (thumbnailsList[0].gameObject.name.Contains("Cut"))
                {
                    if (transform.GetChild(0).GetChild(0).transform.childCount > 1)
                    {
                        Debug.Log("Il a des enfants");
                        ValidateTemporary();
                    }
                    else
                    {
                        Debug.Log("Stop Coroutine Validation");
                        StopAllCoroutines();
                        ValideAction();
                    }
                }
                else
                {
                    WrongAction();
                }
                break;
        }
    }

    public void ValideAction()
    {
        thumbnailsList.RemoveAt(0);
        transform.GetChild(0).GetChild(0).gameObject.GetComponent<Thumbnail>().NeedToDestroy();

        HitMonster();
        Heal();
        NewWave();
    }

    public void ValidateTemporary()
    {
        transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Thumbnail>().NeedToDestroy();

        StartCoroutine("Compteur");
    }

    public IEnumerator Compteur()
    {
        Debug.Log("Rentré");
        yield return new WaitForSeconds(2f);
        //Temps écoulé 
        Debug.Log("Temps écoulé");
        Destroy(transform.GetChild(0).GetChild(0).gameObject);
        Instantiate(thumbnailsList[0], transform.GetChild(0).transform.position, Quaternion.identity, transform.GetChild(0));
    }

    public void WrongAction()
    {
        Damage();
    }

    public void NewWave()
    {
        if (thumbnailsList.Count != 0)
        {
            transform.GetChild(1).GetChild(0).gameObject.GetComponent<Thumbnail>().NeedToMove(transform.GetChild(0).transform.position);
            //StartCoroutine(MoveTo(transform.GetChild(1).GetChild(0).gameObject, transform.GetChild(0).transform.position));
            transform.GetChild(1).GetChild(0).transform.SetParent(transform.GetChild(0));
        }

        if (thumbnailsList.Count > 1)
        {
            transform.GetChild(2).GetChild(0).gameObject.GetComponent<Thumbnail>().NeedToMove(transform.GetChild(1).transform.position);
            //StartCoroutine(MoveTo(transform.GetChild(2).GetChild(0).gameObject, transform.GetChild(1).transform.position));
            transform.GetChild(2).GetChild(0).transform.SetParent(transform.GetChild(1));
        }

        if (thumbnailsList.Count > 2)
        {
            Instantiate(thumbnailsList[2], transform.GetChild(2).transform.position, Quaternion.identity, transform.GetChild(2));
        }
    }

    public void HitMonster()
    {
        monsterLife.nbIconCurrent--;
    }

    public void Heal()
    {
        gm.lifeFill.fillAmount = gm.lifeFill.fillAmount + (1f * 0.02f);
    }

    public void Damage()
    {
        gm.lifeFill.fillAmount = gm.lifeFill.fillAmount - (1f * 0.20f);
    }

    /*public IEnumerator MoveTo(GameObject go, Vector3 targetPos)
    {
        go.transform.position = Vector3.MoveTowards(go.transform.position, targetPos, 0.5f);

        if(Vector3.Distance(go.transform.position, targetPos) > 0.5f)
        {
            StartCoroutine(MoveTo(go, targetPos));
        }
        else
        {
            //End
        }

        yield return new WaitForSeconds(0.1f);
    }*/
}
