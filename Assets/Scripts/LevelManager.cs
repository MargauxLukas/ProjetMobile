using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameObject player;
    public Transform bin;
    public Transform monsterParent;

    public GameObject topScreen;
    public GameObject bottomScreen;
    public GameObject endScreen;

    public GameObject kneadB;
    public GameObject cutB;
    public GameObject whipB;
    public GameObject cookB;
    public GameObject boilB;

    public List<GameObject> obstacles;

    public List<GameObject> level1;
    public List<GameObject> level2;
    public List<GameObject> level3;
    public List<GameObject> level4;
    public List<GameObject> level5;

    public List<GameObject> currentLevel;

    public GameObject phase1Buttons;
    public GameObject phase2Buttons;

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
        if(currentLevel.Count == 1 && !currentLevel[0].name.Contains("Boss"))
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
            //FightManager.instance.ChoosePatterns();
            monster.transform.parent = topScreen.transform;
            gameObject.GetComponent<ButtonsManager>().tm = monster.transform.GetChild(2).GetComponent<ThumbnailManager>();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void NextMonster()
    {
        currentLevel.RemoveAt(0);
        Destroy(topScreen.transform.GetChild(0).gameObject);
        Destroy(monsterParent.transform.GetChild(1).gameObject);
        BeginGame();
        ActivatePhase1();
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
        //dd
    }
}
