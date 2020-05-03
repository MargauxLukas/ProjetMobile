using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameObject player;
    public Transform bin;
    public Transform monsterParent;

    public GameObject topScreen;
    public GameObject bottomScreen;
    public GameObject endScreen;
    public GameObject scoreScreen;

    public GameObject kneadB;
    public GameObject cutB;
    public GameObject whipB;
    public GameObject cookB;
    public GameObject boilB;

    public List<GameObject> obstacles;
    private List<float> positionButtonList = new List<float>() { -224f, 2.5f, 229f };

    public List<GameObject> level1;
    public List<GameObject> level2;
    public List<GameObject> level3;
    public List<GameObject> level4;
    public List<GameObject> level5;

    public List<GameObject> currentLevel;

    public GameObject phase1Buttons;
    public GameObject phase2Buttons;

    public bool isInfinite = false;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ChooseLevel(UIManager.chosenLevel);
    }

    public void ChooseLevel(int i)
    {
        //Debug.Log(i);
        switch (i)
        {
            case 1:
                foreach (GameObject go in level1)
                {
                    cutB.transform.position = whipB.transform.position;
                    whipB.gameObject.SetActive(false);
                    currentLevel.Add(go);
                }
                break;
            case 2:
                foreach (GameObject go in level2)
                {
                    currentLevel.Add(go);
                }
                break;
            case 3:
                foreach (GameObject go in level3)
                {
                    boilB.transform.position = whipB.transform.position;
                    whipB.gameObject.SetActive(false);
                    currentLevel.Add(go);
                }
                break;
            case 4:
                foreach (GameObject go in level4)
                {
                    cookB.transform.position = cutB.transform.position;
                    cutB.gameObject.SetActive(false);
                    currentLevel.Add(go);
                }
                break;
            case 5:
                foreach (GameObject go in level5)
                {
                    currentLevel.Add(go);
                }
                break;
            case 6:
                currentLevel.Add(gameObject.GetComponent<InfiniteLevel>().AddMonster());
                isInfinite = true;
                break;
            default:
                foreach (GameObject go in level3)
                {
                    currentLevel.Add(go);
                }
                break;
        }

        BeginGame();
    }

    public void BeginGame()
    {
        if(currentLevel.Count == 1 && !isInfinite)
        {
            //bottomScreen.SetActive(false);
            endScreen.SetActive(true);
            //TapisManager.instance.transform.parent.gameObject.SetActive(false);                                              

            GameObject monster = Instantiate(currentLevel[0], topScreen.transform);
            monster.transform.GetChild(3).gameObject.transform.position = new Vector3(0f, 0.47f, -2f);
            monster.transform.GetChild(3).gameObject.transform.SetParent(monsterParent);
        }
        else if (currentLevel.Count != 0)
        {
            GameObject monster = Instantiate(currentLevel[0], topScreen.transform);
            TapisManager.instance.TapisOnPhase1();
            monster.transform.GetChild(2).gameObject.transform.position = new Vector3(0f, 0.5f, -2f);
            monster.transform.GetChild(2).gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            monster.transform.GetChild(2).gameObject.transform.SetParent(monsterParent);
            FightManager.instance.percentLife = monster.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Life>().lifeMax * FightManager.instance.percentFight;
            FightManager.instance.timerAttack = 1.5f;
            FightManager.instance.isMonsterAttacking = false;
            FightManager.instance.SetLifeGoal();
            //FightManager.instance.shieldGroup.GetComponent<SpawnShield>().DestroyAll();
            //FightManager.instance.ChoosePatterns();
            monster.transform.parent = topScreen.transform;
            gameObject.GetComponent<ButtonsManager>().tm = monster.transform.GetChild(2).GetComponent<ThumbnailManager>();

            if(isInfinite)
            {
                DesactivateAllButtons();
                ActivateGoodButtons();
            }
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void NextMonster()
    {
        if(isInfinite)
        {
            gameObject.GetComponent<InfiniteLevel>().nbFloor++;
            currentLevel.Add(gameObject.GetComponent<InfiniteLevel>().AddMonster());
        }

        currentLevel.RemoveAt(0);
        Destroy(topScreen.transform.GetChild(0).gameObject);
        Destroy(monsterParent.transform.GetChild(1).gameObject);
        BeginGame();
        ActivatePhase1();
    }

    public void ActivateGoodButtons()
    {
        for(int i = 0; i < 3; i++)
        {
            switch(gameObject.GetComponent<InfiniteLevel>().buttonStringRemove[i])
            {
                case "cut":
                    cutB.transform.localPosition   = new Vector2(positionButtonList[i], 295.5f);
                    cutB.SetActive(true);
                    break;
                case "whip":
                    whipB.transform.localPosition  = new Vector2(positionButtonList[i], 295.5f);
                    whipB.SetActive(true);
                    break;
                case "knead":
                    kneadB.transform.localPosition = new Vector2(positionButtonList[i], 295.5f);
                    kneadB.SetActive(true);
                    break;
                case "cook":
                    cookB.transform.localPosition  = new Vector2(positionButtonList[i], 295.5f);
                    cookB.SetActive(true);
                    break;
                case "boil":
                    boilB.transform.localPosition  = new Vector2(positionButtonList[i], 295.5f);
                    boilB.SetActive(true);
                    break;
            }
        }
    }

    public void DesactivateAllButtons()
    {
        cutB  .SetActive(false);
        whipB .SetActive(false);
        kneadB.SetActive(false);
        cookB .SetActive(false);
        boilB .SetActive(false);
    }

    public void ActivatePhase1()
    {
        phase1Buttons.transform.GetChild(0).GetComponent<ButtonMovePhase1>().needMove = true;
        phase1Buttons.transform.GetChild(1).GetComponent<ButtonMovePhase1>().needMove = true;
    }

    public void ActivatePhase2()
    {
        phase1Buttons.transform.GetChild(0).GetComponent<ButtonMovePhase1>().needMove = true;
        phase1Buttons.transform.GetChild(1).GetComponent<ButtonMovePhase1>().needMove = true;
    }

    public void GoToBin(GameObject go)
    {
        go.transform.SetParent(bin.transform);
    }

    public int GetChip()
    {
        for(int i = 0; i < 4; i++)
        {
            if (ThumbnailManager.instance.transform.GetChild(i).GetChild(0).GetComponent<Thumbnail>().isChip)
            {
                return i;
            }
        }

        return -1;
    }

    public void PlayerDeath()
    {
        Time.timeScale = 0f;
        scoreScreen.SetActive(true);
        scoreScreen.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void PlayerWin()
    {
        Time.timeScale = 0f;
        scoreScreen.SetActive(true);
        scoreScreen.GetComponent<VictoryStars>().SetStars(GameManager.instance.GetPlayerLife());
        scoreScreen.transform.GetChild(0).gameObject.SetActive(true);
    }
}
