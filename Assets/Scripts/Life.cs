using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    [Header("Life")]
    public int lifeMax     = 10;                                //Nombre de point de vie du Monstre
    public int currentLife = 10;                                //Nombre de point de vue actuel

    [Header("Shield")]
    public int countShield   = 10;                              //Le nombre de bouclier que le monstre se mettra à chaque protection
    public int currentShield =  0;                              //Le nombre de bouclier actuel

    private float nb;                                           //Le nombre de vie que le monstre perd par coup
    private bool stuned = false;

    private FightManager fm;
    private LevelManager lm;

    private void Start()
    {
        fm = FightManager.instance;
        lm = LevelManager.instance;
    }

    public void Update()
    {
        nb = 1 / (float)lifeMax;
        if (!stuned)
        {
            GetComponent<Image>().fillAmount = nb * currentLife;

            if (currentLife == 0)
            {
                if(ThumbnailManager.instance.thumbnailsList.Count == 0)
                {
                    ReturnToMenuException();                                                                                                           //Si le monstre n'a pas de Thumbnail, le joueur gagne directement
                }

                stuned = true;
                lm.particle     .transform.GetChild(1).gameObject.SetActive(true);                                                                     //Activation VFX Stunned
                lm.monsterParent.transform.GetChild(1).GetComponent<Animator>().SetBool("isAttack", false);
                lm.monsterParent.transform.GetChild(1).GetComponent<Animator>().SetBool("isStun", true);
                fm.isMonsterAttacking = false;
                fm.timerAttack = 1.5f;
                ThumbnailManager.instance.phase1 = false;
                UIManager.instance.SwitchMusicToPreparation();

                currentShield = 0;                                                                                                                      //SECURITÉ : On met le nombre de bouclier actuel à 0 ! 
                for (int i = 0; i < fm.shieldGroup.transform.childCount; i++)
                {
                    Destroy(fm.shieldGroup.transform.GetChild(i).gameObject);                                                                           //SECURITÉ : On détruit les boucliers au cas-ou ! 
                }

                TapisManager.instance.TapisOnPhase2();
                lm.ActivatePhase2();

                if (ThumbnailManager.instance.transform.GetChild(0).transform.childCount > 0) {ThumbnailManager.instance.ShowThumbnail()  ;}
                else                                                                          {ThumbnailManager.instance.ChooseThumbnail();}

                if(LevelManager.instance.level2Tuto)
                {
                    TutorialManager.instance.Level2Stunned();
                }
            }
        }
        else
        {
            if (Time.timeScale != 0f)
            {
                if (UIManager.difficulty == "Noob" || UIManager.difficulty == "Easy")
                {
                    GetComponent<Image>().fillAmount += 0.003f;
                }
                else if (UIManager.difficulty == "Medium" || UIManager.difficulty == "Hard")
                    {
                        GetComponent<Image>().fillAmount += 0.005f;
                    }
            }

            if (GetComponent<Image>().fillAmount == 1f)
            {
                stuned = false;
                lm.particle.transform.GetChild(1).gameObject.SetActive(false);
                lm.monsterParent.transform.GetChild(1).GetComponent<Animator>().SetBool("isStun", false);
                ThumbnailManager.instance.HideThumbnail();
                currentLife = lifeMax;
                currentShield = 0;
                fm.SetLifeGoal();
                ThumbnailManager.instance.phase1 = true;
                UIManager.instance.SwitchMusicToCombat();
                TapisManager.instance.TapisOnPhase1();
                lm.ActivatePhase1();
            }
        }
    }

    public void ReturnToMenuException()
    {
        if (PlayerPrefs.GetInt("level") == UIManager.chosenLevel)
        {
            PlayerPrefs.SetInt("level", UIManager.chosenLevel + 1);
        }

        LevelManager.instance.PlayerWin();
    }
}
