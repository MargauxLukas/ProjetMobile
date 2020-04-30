using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class ThumbnailManager : MonoBehaviour
{
    public static ThumbnailManager instance;

    public enum patterns { Neutral, Agressive, Scared, Anxious, Bipolar };
    public patterns pattern = patterns.Neutral;

    public Life monsterLife;
    public GameManager gm;

    public List<GameObject> thumbnailsList;

    private int random;
    private float posStart;
    private float posEnd;
    private float swipeDifference;

    public int vignetteNb;

    public bool knead = false;
    public bool cook = false;
    public bool whip = false;
    public bool boil = false;

    public bool phase1 = true;
    public float distance1 = 0f;
    public float distance2 = 0f;
    public Vector2 touchun;
    public Vector2 touchdeux;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        //ChooseThumbnail();
    }

    public void Update()
    {
        if(!phase1)
        {
            if (thumbnailsList.Count != 0 && vignetteNb < thumbnailsList.Count)
            {
                if (thumbnailsList[vignetteNb].gameObject != null)
                {
                    if (thumbnailsList[vignetteNb].gameObject.name.Contains("KneadMaintain") && Input.GetMouseButton(0) && knead)
                    {
                        transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<RectTransform>().localPosition += new Vector3(2f,0,0);

                        if (transform.GetChild(0).GetChild(0).GetChild(1).transform.localPosition.x > 40f)
                        {
                            ValideAction();
                        }
                    }
                    else if (thumbnailsList[vignetteNb].gameObject.name.Contains("KneadMaintain") && !knead && transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<RectTransform>().localPosition.x > -50f)
                    {
                        transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<RectTransform>().localPosition -= Vector3.right;
                    }

                    if (thumbnailsList[vignetteNb].gameObject.name.Contains("CookMaintain") && Input.GetMouseButton(0) && cook)
                    {
                        transform.GetChild(vignetteNb).GetChild(0).GetChild(1).GetComponent<RectTransform>().localPosition += Vector3.right;

                        if (transform.GetChild(vignetteNb).GetChild(0).GetChild(1).transform.localPosition.x > 40f)
                        {
                            ValideAction();
                        }
                    }
                }

                /*else if (thumbnailsList[0].gameObject.name.Contains("KneadMaintain") && Input.GetMouseButtonUp(0))
                {
                    if (transform.GetChild(0).GetChild(0).GetChild(1).transform.localPosition.x > 40f && transform.GetChild(0).GetChild(0).GetChild(1).transform.localPosition.x < 50f)
                    {
                        ValideAction();
                    }
                    else
                    {
                        transform.GetChild(0).GetChild(0).GetChild(1).transform.localPosition = new Vector3(-50f, transform.GetChild(0).GetChild(0).GetChild(1).transform.localPosition.y,
                                                                                                             transform.GetChild(0).GetChild(0).GetChild(1).transform.localPosition.z);
                    }
                }*/
                if (Input.touchCount > 0)
                {
                    //TOUCH
                    if (thumbnailsList[vignetteNb].gameObject.name.Contains("WhipMixed") && whip)
                    {
                        Debug.Log("Touch");
                        Touch touch = Input.GetTouch(0);

                        if (touch.phase == TouchPhase.Began)
                        {
                            posStart = touch.position.y;
                        }
                        if (touch.phase == TouchPhase.Ended)
                        {
                            posEnd = touch.position.y;
                        }
                        else
                        {
                            return;
                        }

                        swipeDifference = Mathf.Abs(posStart - posEnd);

                        if (posEnd < posStart && swipeDifference > 200f)
                        {
                            Debug.Log(swipeDifference);
                            whip = false;
                            ValideAction();
                        }
                        else
                        {
                            whip = false;
                            return;
                        }
                    }
                    else if(thumbnailsList[vignetteNb].gameObject.name.Contains("BoilLaunch") && boil)
                    {
                        Debug.Log("Touch");
                        Touch touch = Input.GetTouch(0);

                        if (touch.phase == TouchPhase.Began)
                        {
                            posStart = touch.position.y;
                        }
                        if (touch.phase == TouchPhase.Ended)
                        {
                            posEnd = touch.position.y;
                        }
                        else
                        {
                            return;
                        }

                        swipeDifference = Mathf.Abs(posStart - posEnd);
                        Debug.Log(swipeDifference);

                        if (posEnd > posStart && swipeDifference > 200f)
                        {
                            Debug.Log(swipeDifference);
                            boil = false;
                            ValideAction();
                        }
                        else
                        {
                            boil = false;
                            return;
                        }
                    }

                    /*if (Input.touchCount >= 2)
                    {
                        Touch touch1 = Input.GetTouch(0);
                        Touch touch2 = Input.GetTouch(1);

                        if (thumbnailsList[vignetteNb].gameObject.name.Contains("KneadPinch") && knead)
                        {
                            if (touch1.phase == TouchPhase.Moved)
                            {
                                touchun = Input.GetTouch(0).position;

                            }
                            if (touch2.phase == TouchPhase.Moved)
                            {
                                touchdeux = Input.GetTouch(1).position;
                            }

                            if (distance1 == 0f)
                            {
                                distance1 = Vector2.Distance(touchun, touchdeux); 
                            }

                            distance2 = Vector2.Distance(touchun, touchdeux); 

                            if (distance2 < distance1 && distance2 <= distance1 * 0.20f)                                 // % voulue lors du Pinch, on veut que Distance 2 soit inférieure à 80% de distance1
                            {
                                distance1 = 0f;
                                distance2 = 0f;
                                knead = false;
                                ValideAction();
                            }
                            else
                            {
                                return;
                            }

                        }
                    }*/
                }
            }
        }
    }

    public void ChooseThumbnail()
    {
        Instantiate(thumbnailsList[0], transform.GetChild(0).transform.position, Quaternion.identity, transform.GetChild(0));
        SpawnObstacle(0);
        transform.GetChild(0).GetChild(0).GetComponent<Thumbnail>().isFirst = true;

        if (thumbnailsList.Count > 1)
        {
            Instantiate(thumbnailsList[1], transform.GetChild(1).transform.position, Quaternion.identity, transform.GetChild(1));
            SpawnObstacle(1);
        }

        if (thumbnailsList.Count > 2)
        {
            Instantiate(thumbnailsList[2], transform.GetChild(2).transform.position, Quaternion.identity, transform.GetChild(2));
            SpawnObstacle(2);
        }

        if (thumbnailsList.Count > 3)
        {
            Instantiate(thumbnailsList[3], transform.GetChild(3).transform.position, Quaternion.identity, transform.GetChild(3));
            SpawnObstacle(3);
        }
    }

    public void CheckAction(int nbAction)
    {
        for (vignetteNb = 0; vignetteNb < 3; vignetteNb++)
        {
            if (!thumbnailsList[vignetteNb].gameObject.name.Contains("Lock") || !transform.GetChild(vignetteNb).GetChild(0).gameObject.GetComponent<Thumbnail>().isLocked)
            {
                break;
            }
        }

        switch(nbAction)
        {
            case 1:
                if (thumbnailsList[vignetteNb].gameObject.name.Contains("Whip") && !transform.GetChild(vignetteNb).GetChild(0).gameObject.GetComponent<Thumbnail>().isPotato)
                {
                    if (thumbnailsList[vignetteNb].gameObject.name.Contains("WhipMix"))
                    {
                        return;
                    }
                    else
                    {
                        ThumbnailReplace.instance.WhipFinish();
                        ValideAction();
                    }
                }
                else
                {
                    WrongAction();
                }
                break;
            case 2:
                    if (thumbnailsList[vignetteNb].gameObject.name.Contains("Knead") && !transform.GetChild(vignetteNb).GetChild(0).gameObject.GetComponent<Thumbnail>().isPotato)
                    {
                        if (thumbnailsList[vignetteNb].gameObject.name.Contains("KneadMaintain") /*|| thumbnailsList[vignetteNb].gameObject.name.Contains("KneadPinch")*/)
                        {
                            return;
                        }
                        else
                        {
                            ThumbnailReplace.instance.KneadFinish();
                            ValideAction();
                        }
                    }
                    else
                    {
                        WrongAction();
                    }
                
                break;
            case 3:
                if (thumbnailsList[vignetteNb].gameObject.name.Contains("Cut") && !transform.GetChild(vignetteNb).GetChild(0).gameObject.GetComponent<Thumbnail>().isPotato)
                {
                    if (transform.GetChild(vignetteNb).GetChild(0).transform.childCount > 1)
                    {
                        Debug.Log("Il a des enfants");
                        ThumbnailReplace.instance.ChooseCut(thumbnailsList[vignetteNb].gameObject.name);
                        ValidateTemporary();
                    }
                    else
                    {
                        Debug.Log("Stop Coroutine Validation");
                        StopAllCoroutines();
                        ThumbnailReplace.instance.ChooseCut(thumbnailsList[vignetteNb].gameObject.name);
                        ThumbnailReplace.instance.ResetNbCut();
                        FightManager.instance.MonsterCut();
                        ValideAction();
                    }
                }
                else
                {
                    WrongAction();
                }
                break;
            case 4:
                if (thumbnailsList[vignetteNb].gameObject.name.Contains("Cook") && !transform.GetChild(vignetteNb).GetChild(0).gameObject.GetComponent<Thumbnail>().isPotato)
                {
                    if (thumbnailsList[vignetteNb].gameObject.name.Contains("CookMaintain"))
                    {
                        return;
                    }
                    else
                    {
                        LevelManager.instance.monsterParent.transform.GetChild(1).GetComponent<Animator>().SetBool("isFire", true);
                        ThumbnailReplace.instance.CookFinish();
                        ValideAction();
                    }
                }
                else
                {
                    WrongAction();
                }
                break;
            case 5:
                if (thumbnailsList[vignetteNb].gameObject.name.Contains("Boil") && !transform.GetChild(vignetteNb).GetChild(0).gameObject.GetComponent<Thumbnail>().isPotato)
                {
                    if (thumbnailsList[vignetteNb].gameObject.name.Contains("BoilLaunch"))
                    {
                        return;
                    }
                    else
                    {
                        ThumbnailReplace.instance.BoilFinish();
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
        thumbnailsList.RemoveAt(vignetteNb);
        transform.GetChild(vignetteNb).GetChild(0).gameObject.GetComponent<Thumbnail>().NeedToDestroy();

        if(vignetteNb != 0)
        {
            Unlock();
        }

        HitMonster();
        Heal();
    }

    public void Unlock(GameObject go = null)
    {
        if (go != null)
        {
            go.GetComponent<Thumbnail>().isLocked = false;
            Destroy(go.transform.Find("Lock").gameObject);
        }
        else
        {
            transform.GetChild(0).GetChild(0).gameObject.GetComponent<Thumbnail>().isLocked = false;
            Destroy(transform.GetChild(0).GetChild(0).Find("Lock").gameObject);
        }
    }

    public void ValidateTemporary()
    {
        transform.GetChild(vignetteNb).GetChild(0).GetChild(0).gameObject.GetComponent<Thumbnail>().NeedToDestroy();

        StartCoroutine("Compteur");
    }

    public IEnumerator Compteur()
    {
        Debug.Log("Rentré");
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Temps écoulé");
        Destroy(transform.GetChild(vignetteNb).GetChild(0).gameObject);
        GameObject inst = Instantiate(thumbnailsList[vignetteNb], transform.GetChild(vignetteNb).transform.position, Quaternion.identity, transform.GetChild(vignetteNb));

        if(vignetteNb == 0)
        {
            inst.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(180f, 180f);
        }
        if (inst.name.Contains("Locked"))
        {
            Unlock(inst);
        }
        ThumbnailReplace.instance.ResetNbCut();

        if(thumbnailsList.Count < 2 )
        {
            Unlock(inst);
        }
    }

    public void WrongAction()
    {
        Damage();
    }

    public void NewWave()
    {
        if (thumbnailsList.Count != 0 && transform.GetChild(1).childCount > 0 && transform.GetChild(0).childCount == 0)
        {
            transform.GetChild(1).GetChild(0).gameObject.GetComponent<Thumbnail>().NeedToMove(transform.GetChild(0).transform.position);
            transform.GetChild(1).GetChild(0).gameObject.GetComponent<Thumbnail>().isFirst = true;
            transform.GetChild(1).GetChild(0).transform.SetParent(transform.GetChild(0));
        }

        if (thumbnailsList.Count > 1 && transform.GetChild(1).childCount == 0)
        {
            transform.GetChild(2).GetChild(0).gameObject.GetComponent<Thumbnail>().NeedToMove(transform.GetChild(1).transform.position);
            transform.GetChild(2).GetChild(0).transform.SetParent(transform.GetChild(1));
        }

        if (thumbnailsList.Count > 2)
        {
            transform.GetChild(3).GetChild(0).gameObject.GetComponent<Thumbnail>().NeedToMove(transform.GetChild(2).transform.position);
            transform.GetChild(3).GetChild(0).transform.SetParent(transform.GetChild(2));
            //Instantiate(thumbnailsList[2], transform.GetChild(2).transform.position, Quaternion.identity, transform.GetChild(2));
        }

        if (thumbnailsList.Count > 3)
        {
            Instantiate(thumbnailsList[3], transform.GetChild(3).transform.position, Quaternion.identity, transform.GetChild(3));
            SpawnObstacle(3);
        }
    }

    public void HitMonster()
    {
        LevelManager.instance.monsterParent.transform.GetChild(1).GetComponent<Animator>().SetBool("isCut", false);
        LevelManager.instance.monsterParent.transform.GetChild(1).GetComponent<Animator>().SetBool("isBoil", false);
        LevelManager.instance.monsterParent.transform.GetChild(1).GetComponent<Animator>().SetBool("isFire", false);

        if (thumbnailsList.Count == 0)
        {
            FightManager.instance.MonsterDeath();        
        }
        else
        {
            NewWave();
        }
    }

    public void Heal()
    {
        gm.lifeFill.fillAmount = gm.lifeFill.fillAmount + (1f * 0.05f);
    }

    public void Damage()
    {
        gm.lifeFill.fillAmount = gm.lifeFill.fillAmount - (1f * 0.20f);
    }

    public void HideThumbnail()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
    }

    public void ShowThumbnail()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(false);
    }

    public void SpawnObstacle(int i)
    {
        int random = Random.Range(1, 11);

        if(random == 1)
        {
            transform.GetChild(i).GetChild(0).GetComponent<Thumbnail>().isPotato = true;
            Instantiate(LevelManager.instance.obstacle, transform.GetChild(i).transform.position, Quaternion.identity, transform.GetChild(i).GetChild(0));
        }
    }
}
