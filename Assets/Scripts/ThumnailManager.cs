using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThumnailManager : MonoBehaviour
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

    public void ChooseThumbnail()
    {
        for(int i = 0; i < 10; i++)
        {
            random = Random.Range(0, 3);
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
                    ValideAction();
                }
                else
                {
                    WrongAction();
                }
                break;
            case 3:
                if (thumbnailsList[0].gameObject.name.Contains("Cut"))
                {
                    ValideAction();
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
        Destroy(transform.GetChild(0).GetChild(0).gameObject);

        HitMonster();
        Heal();
        NewWave();
    }

    public void WrongAction()
    {
        Damage();
    }

    public void NewWave()
    {
        if (thumbnailsList.Count != 0)
        {
            transform.GetChild(1).GetChild(0).position = transform.GetChild(0).transform.position;
            transform.GetChild(1).GetChild(0).transform.parent = transform.GetChild(0);
        }

        if (thumbnailsList.Count > 1)
        {
            transform.GetChild(2).GetChild(0).position = transform.GetChild(1).transform.position;
            transform.GetChild(2).GetChild(0).transform.parent = transform.GetChild(1);
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
}
