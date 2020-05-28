using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{
    public static FightManager instance;

    public GameObject shieldGroup;
    public GameObject targetThumb;

    public AudioClip damageClip;

    public float percentFight = 0.15f;
    public float percentLife;
    public float lifeGoal;

    //Monster
    public bool isMonsterAttacking = false;

    //Player
    public bool isPlayerDefending;
    public bool isWaiting;

    public int rand;

    public bool isAttacked = false;

    public float timerAttack = 1.517f;
    private float timeCooldown = 5f;

    public float timeBetweenAction = 4f;
    private int chipLife = 1;

    public void Awake()
    {
        instance = this;
    }

    void Update()
    {
        //Debug.Log(ThumbnailManager.instance.monsterLife.currentLife + " <= " + lifeGoal);
        if (ThumbnailManager.instance.phase1)
        {
            //Tout les 15% ou 5 secondes mais 1 à 4 secondes apres Actions il peut rien faire
            if (isMonsterAttacking)
            {
                timerAttack -= Time.deltaTime;

                if (timerAttack <= 0)
                {
                    CheckDamage();
                }
            }
            else if (ThumbnailManager.instance.monsterLife.currentLife <= lifeGoal || timeCooldown <= 0)
            {
                //Debug.Log(ThumbnailManager.instance.monsterLife.currentLife + " <= " + lifeGoal);
                Action();
            }
            else
            {
                timeCooldown -= Time.deltaTime;
            }
        }
    }

    public void CheckDamage()
    {
        LevelManager.instance.monsterParent.transform.GetChild(1).GetComponent<Animator>().SetBool("isAttack", false);
        isMonsterAttacking = false;
        SetTimeAction();
        SetLifeGoal();
        timerAttack = 1.517f;

        if (!isPlayerDefending)
        {
            //Debug.Log("Degat ! ");
            Player.instance.GetComponent<AudioSource>().clip = damageClip;
            Player.instance.GetComponent<AudioSource>().Play();
            GameManager.instance.lifeFill.fillAmount -= 0.15f;
        }
    }

    public void ChoosePatterns()
    {
        rand = UnityEngine.Random.Range(1,6);

        switch(rand)
        {
            case 1:
                ThumbnailManager.instance.pattern = ThumbnailManager.patterns.Neutral;
                break;
            case 2:
                ThumbnailManager.instance.pattern = ThumbnailManager.patterns.Agressive;
                break;
            case 3:
                ThumbnailManager.instance.pattern = ThumbnailManager.patterns.Scared;
                break;
            case 4:
                ThumbnailManager.instance.pattern = ThumbnailManager.patterns.Anxious;
                break;
            case 5:
                ThumbnailManager.instance.pattern = ThumbnailManager.patterns.Bipolar;
                break;
        }
    }

    public void Action()
    {
        timeCooldown = 30f;

        switch(ThumbnailManager.instance.pattern)
        {
            case ThumbnailManager.patterns.Neutral:
                Rand(1, 2);                                                                                     //1 chance(Att) sur 2
                break;
            case ThumbnailManager.patterns.Agressive:                                                                            // 3 chance(Att) sur 4
                Rand(3, 4);
                break;
            case ThumbnailManager.patterns.Scared:                                                                               // 1 chance(Att) sur 4
                Rand(1, 4);
                break;
            case ThumbnailManager.patterns.Anxious:                                                                              // 4 chance(Att) sur 5 PUIS 1 chance(Att) sur 5
                if (ThumbnailManager.instance.monsterLife.currentLife > ThumbnailManager.instance.monsterLife.lifeMax / 2)
                {
                    Rand(4, 5);
                }
                else
                {
                    Rand(1, 5);
                }
                break;
            case ThumbnailManager.patterns.Bipolar:                                                                              // 1 chance(Att) sur 10 PUIS 9 chance(Att) sur 10
                if (isAttacked)
                {
                    Rand(1, 10);
                }
                else
                {
                    Rand(9, 10);
                }
                break;
        }
    }

    public void SetLifeGoal()
    {
        lifeGoal = ThumbnailManager.instance.monsterLife.currentLife - percentLife;
    }

    public void Rand(int chance, int surCombien)
    {
        rand = UnityEngine.Random.Range(1, surCombien+1);
        //Debug.Log(rand + " = " + chance + " chance sur " + surCombien);
        if(rand <= chance || ThumbnailManager.instance.monsterLife.currentShield > 0)
        {
            MonsterAttack();
        }
        else
        {
            MonsterDefend();
        }
    }

    public void MonsterAttack()
    {
        LevelManager.instance.monsterParent.transform.GetChild(1).GetComponent<Animator>().SetBool("isAttack", true);
        timeCooldown = timerAttack;
        isMonsterAttacking = true;
    }

    public void MonsterDefend()
    {
        SetLifeGoal();
        SetTimeAction();
        ThumbnailManager.instance.monsterLife.currentShield = ThumbnailManager.instance.monsterLife.countShield;
        shieldGroup.GetComponent<SpawnShield>().ShieldInstance(ThumbnailManager.instance.monsterLife.countShield);
        isMonsterAttacking = false;
    }

    public void MonsterCut()
    {
        LevelManager.instance.monsterParent.transform.GetChild(1).GetComponent<Animator>().SetTrigger("isCutting");
        Instantiate(LevelManager.instance.player.GetComponent<PrefabSFX>().cut_VFX, new Vector3(LevelManager.instance.monsterParent.GetChild(1).position.x,
                                                                                                 LevelManager.instance.monsterParent.GetChild(1).position.y,
                                                                                                 -3f),
                                                                                                 Quaternion.identity,
                                                                                                 LevelManager.instance.player.GetComponent<PrefabSFX>().groupVFX.transform);
        MonsterBlood();
    }


    public void MonsterBoil()
    {
        LevelManager.instance.monsterParent.transform.GetChild(1).GetComponent<Animator>().SetTrigger("isBoil");
        Instantiate(LevelManager.instance.player.GetComponent<PrefabSFX>().boil_VFX, new Vector3(LevelManager.instance.monsterParent.GetChild(1).position.x, 
                                                                                                 LevelManager.instance.monsterParent.GetChild(1).position.y, 
                                                                                                 -3f), 
                                                                                                 Quaternion.identity, 
                                                                                                 LevelManager.instance.player.GetComponent<PrefabSFX>().groupVFX.transform);

        MonsterBlood();
    }

    public void MonsterCook()
    {
        LevelManager.instance.monsterParent.transform.GetChild(1).GetComponent<Animator>().SetTrigger("isFire");
        Instantiate(LevelManager.instance.player.GetComponent<PrefabSFX>().fire_VFX, new Vector3(LevelManager.instance.monsterParent.GetChild(1).position.x,
                                                                                                 LevelManager.instance.monsterParent.GetChild(1).position.y,
                                                                                                 -3f),
                                                                                                 Quaternion.identity,
                                                                                                 LevelManager.instance.player.GetComponent<PrefabSFX>().groupVFX.transform);

        MonsterBlood();
    }

    public void MonsterKnead()
    {
        LevelManager.instance.monsterParent.transform.GetChild(1).GetComponent<Animator>().SetTrigger("isKnead");
        Instantiate(LevelManager.instance.player.GetComponent<PrefabSFX>().knead_VFX, new Vector3(LevelManager.instance.monsterParent.GetChild(1).position.x,
                                                                                                 LevelManager.instance.monsterParent.GetChild(1).position.y,
                                                                                                 -3f),
                                                                                                 Quaternion.identity,
                                                                                                 LevelManager.instance.player.GetComponent<PrefabSFX>().groupVFX.transform);

        MonsterBlood();
    }

    public void MonsterWhip()
    {
        LevelManager.instance.monsterParent.transform.GetChild(1).GetComponent<Animator>().SetTrigger("isWhip");
        Instantiate(LevelManager.instance.player.GetComponent<PrefabSFX>().mix_VFX, new Vector3(LevelManager.instance.monsterParent.GetChild(1).position.x,
                                                                                                 LevelManager.instance.monsterParent.GetChild(1).position.y,
                                                                                                 -3f),
                                                                                                 Quaternion.identity,
                                                                                                 LevelManager.instance.player.GetComponent<PrefabSFX>().groupVFX.transform);

        MonsterBlood();
    }

    public void MonsterBlood()
    {
        Instantiate(LevelManager.instance.player.GetComponent<PrefabSFX>().blood_VFX, new Vector3(LevelManager.instance.monsterParent.GetChild(1).position.x,
                                                                                         LevelManager.instance.monsterParent.GetChild(1).position.y,
                                                                                         -3f),
                                                                                         Quaternion.identity,
                                                                                         LevelManager.instance.player.GetComponent<PrefabSFX>().groupVFX.transform);
    }

    public void MonsterDeath()
    {
        LevelManager.instance.monsterParent.transform.GetChild(1).GetComponent<Animator>().SetBool("isDeath", true);

        StartCoroutine("PlayDeathAnim", ThumbnailManager.instance.transform.parent.GetComponent<UniqueValues>().animDeathTime);
    }

    public void Attack()
    {
        isPlayerDefending = false;

        if (ThumbnailManager.instance.monsterLife.currentShield <= 0)
        {
            ThumbnailManager.instance.monsterLife.currentLife--;
        }
    }

    public void Defend()
    {
        isPlayerDefending = true;
    }

    public void DontDefend()
    {
        isPlayerDefending = false;
    }

    public void Eat()
    {
        if (ThumbnailManager.instance.phase1)
        {
            ThumbnailManager.instance.monsterLife.currentShield--;
            Destroy(shieldGroup.transform.GetChild(0).gameObject);

            if (ThumbnailManager.instance.monsterLife.currentShield == 0)
            {
                SetTimeAction();
            }
        }
        else
        {
            int vignetteWhereChipIs = LevelManager.instance.GetChip();

            if (vignetteWhereChipIs != -1)
            {
                chipLife--;

                if (chipLife <= 0)
                {
                    for(int i = 0; i < ThumbnailManager.instance.transform.GetChild(vignetteWhereChipIs).GetChild(0).childCount; i++)
                    {
                        if(ThumbnailManager.instance.transform.GetChild(vignetteWhereChipIs).GetChild(0).GetChild(i).name.Contains("Chip"))
                        {
                            Destroy(ThumbnailManager.instance.transform.GetChild(vignetteWhereChipIs).GetChild(0).GetChild(i).gameObject);
                        }
                    }

                    ThumbnailManager.instance.transform.GetChild(vignetteWhereChipIs).GetChild(0).GetComponent<Thumbnail>().isChip = false;
                    chipLife = 1;
                }
            }
            else
            {
                ThumbnailManager.instance.Damage();
            }
        }
    }

    public void EatAll()
    {
        ThumbnailManager.instance.monsterLife.currentShield = 0;

        for(int i = 0; i < shieldGroup.transform.childCount; i++)
        {
            Destroy(shieldGroup.transform.GetChild(i).gameObject);
        }

        SetTimeAction();
    }

    public void SetTimeAction()
    {
        timeBetweenAction = UnityEngine.Random.Range(2f, 5f);
        timeCooldown = timeBetweenAction;
    }

    IEnumerator PlayDeathAnim(float time)
    {
        yield return new WaitForSeconds(time);
        LevelManager.instance.NextMonster();
    }
}
