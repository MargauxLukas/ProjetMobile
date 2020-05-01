using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public int lifeMax = 10;
    public int currentLife = 10;
    public int countShield = 10;
    public int currentShield = 0;

    public float nb;
    public bool stuned = false;
    public bool platFinal = false;

    public void Update()
    {
        nb = 1 / (float)lifeMax;
        if (!stuned)
        {
            GetComponent<Image>().fillAmount = nb * currentLife;

            if (currentLife == 0)
            {
                stuned = true;
                LevelManager.instance.monsterParent.transform.GetChild(1).GetComponent<Animator>().SetBool("isAttack", false);
                ThumbnailManager.instance.phase1 = false;
                TapisManager.instance.TapisOnPhase2();
                FightManager.instance.attackText.SetActive(false);
                FightManager.instance.defendText.SetActive(false);
                LevelManager.instance.ActivatePhase2();

                if (ThumbnailManager.instance.transform.GetChild(0).transform.childCount > 0)
                {
                    ThumbnailManager.instance.ShowThumbnail();
                }
                else
                {
                    ThumbnailManager.instance.ChooseThumbnail();
                }
            }
        }
        else
        {
            GetComponent<Image>().fillAmount += 0.003f;

            if (GetComponent<Image>().fillAmount == 1f)
            {
                ThumbnailManager.instance.HideThumbnail();
                currentLife = lifeMax;
                currentShield = 0;
                ThumbnailManager.instance.phase1 = true;
                TapisManager.instance.TapisOnPhase1();
                LevelManager.instance.ActivatePhase1();
                stuned = false;
            }
        }

    }
}
