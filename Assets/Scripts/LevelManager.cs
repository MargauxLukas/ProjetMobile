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
    public GameObject infiniteScreen;

    public GameObject kneadB;
    public GameObject cutB;
    public GameObject whipB;
    public GameObject cookB;
    public GameObject boilB;

    public List<GameObject> obstacles;
    private List<float> positionLeftButtonList = new List<float> {32, 260, 485 };
    private List<float> positionRightButtonList = new List<float> {480, 254, 26 };

    public List<GameObject> level1;
    public List<GameObject> level2;
    public List<GameObject> level3;
    public List<GameObject> level4;
    public List<GameObject> level5;

    public List<GameObject> currentLevel;

    public GameObject phase1Buttons;
    public GameObject phase2Buttons;

    public bool isInfinite = false;
    public int countMonster;

    public GameObject beginTextGameObject;
    public GameObject eatItTextGameObject;

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
        switch (i)
        {
            case 1:
                foreach (GameObject go in level1)
                {
                    cutB.transform.position = whipB.transform.position;
                    whipB.gameObject.SetActive(false);
                    currentLevel.Add(go);
                }
                countMonster = level1.Count;
                break;
            case 2:
                foreach (GameObject go in level2)
                {
                    currentLevel.Add(go);
                }
                countMonster = level2.Count;
                break;
            case 3:
                foreach (GameObject go in level3)
                {
                    boilB.transform.position = whipB.transform.position;
                    whipB.gameObject.SetActive(false);
                    currentLevel.Add(go);
                }
                countMonster = level3.Count;
                break;
            case 4:
                foreach (GameObject go in level4)
                {
                    cookB.transform.position = cutB.transform.position;
                    cutB.gameObject.SetActive(false);
                    currentLevel.Add(go);
                }
                countMonster = level4.Count;
                break;
            case 5:
                foreach (GameObject go in level5)
                {
                    currentLevel.Add(go);
                }
                countMonster = level5.Count;
                break;
            case 6:
                currentLevel.Add(gameObject.GetComponent<InfiniteLevel>().AddMonster());
                isInfinite = true;
                if (LevelManager.instance.isInfinite)
                {
                    LevelManager.instance.DesactivateAllButtons();
                    LevelManager.instance.ActivateGoodButtons();
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
        if(currentLevel.Count == 1 && !isInfinite)
        {
            bottomScreen.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
            endScreen.SetActive(true);
            //TapisManager.instance.transform.parent.gameObject.SetActive(false);                                              

            GameObject monster = Instantiate(currentLevel[0], topScreen.transform);
            monster.transform.GetChild(3).gameObject.transform.position = new Vector3(0f, 0.47f, -2f);
            monster.transform.GetChild(3).gameObject.transform.SetParent(monsterParent);

            Time.timeScale = 0f;
            eatItTextGameObject.SetActive(true);
            eatItTextGameObject.transform.GetChild(2).GetComponent<Animator>().SetBool("isBegin", true);
            StartCoroutine("WaitAnimationEat");
        }
        else if (currentLevel.Count != 0)
        {
            GameObject monster = Instantiate(currentLevel[0], topScreen.transform);
            TapisManager.instance.TapisOnPhase1();
            monster.transform.GetChild(2).gameObject.transform.position = new Vector3(0f, 0.5f, -2f);
            //monster.transform.GetChild(2).gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            monster.transform.GetChild(2).gameObject.transform.SetParent(monsterParent);
            //monsterParent.transform.GetChild(1).transform.localScale = new Vector3(0.5f , 0.5f, 0.5f);
            FightManager.instance.percentLife = monster.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Life>().lifeMax * FightManager.instance.percentFight;
            FightManager.instance.timerAttack = 1.5f;
            FightManager.instance.isMonsterAttacking = false;
            FightManager.instance.SetLifeGoal();
            //FightManager.instance.shieldGroup.GetComponent<SpawnShield>().DestroyAll();
            //FightManager.instance.ChoosePatterns();
            monster.transform.SetParent(topScreen.transform);
            gameObject.GetComponent<ButtonsManager>().tm = monster.transform.GetChild(2).GetComponent<ThumbnailManager>();
        }
        else
        {
            SceneManager.LoadScene(0);
        }

        if(currentLevel.Count == countMonster || ThumbnailManager.instance.thumbnailsList.Count == 1)
        {
            Time.timeScale = 0f;
            beginTextGameObject.transform.GetChild(2).GetComponent<Animator>().SetBool("isBegin", true);
            StartCoroutine("WaitAnimationFight");
        }
    }

    IEnumerator WaitAnimationFight()
    {
        yield return new WaitForSecondsRealtime(1.333f);
        Time.timeScale = 1f;
        Destroy(beginTextGameObject.gameObject);
    }

    IEnumerator WaitAnimationEat()
    {
        yield return new WaitForSecondsRealtime(1.333f);
        Time.timeScale = 1f;
        Destroy(eatItTextGameObject.gameObject);
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
                    cutB.GetComponent<RectTransform>().offsetMax = new Vector2(-positionRightButtonList[i], cutB.GetComponent<RectTransform>().offsetMax.y);
                    cutB.GetComponent<RectTransform>().offsetMin = new Vector2(positionLeftButtonList[i], cutB.GetComponent<RectTransform>().offsetMin.y);
                    cutB.SetActive(true);
                    break;
                case "whip":
                    whipB.GetComponent<RectTransform>().offsetMax = new Vector2(-positionRightButtonList[i], whipB.GetComponent<RectTransform>().offsetMax.y);
                    whipB.GetComponent<RectTransform>().offsetMin = new Vector2(positionLeftButtonList[i], whipB.GetComponent<RectTransform>().offsetMin.y);
                    whipB.SetActive(true);
                    break;
                case "knead":
                    kneadB.GetComponent<RectTransform>().offsetMax = new Vector2(-positionRightButtonList[i], kneadB.GetComponent<RectTransform>().offsetMax.y);
                    kneadB.GetComponent<RectTransform>().offsetMin = new Vector2(positionLeftButtonList[i], kneadB.GetComponent<RectTransform>().offsetMin.y);
                    kneadB.SetActive(true);
                    break;
                case "cook":
                    cookB.GetComponent<RectTransform>().offsetMax = new Vector2(-positionRightButtonList[i], cookB.GetComponent<RectTransform>().offsetMax.y);
                    cookB.GetComponent<RectTransform>().offsetMin = new Vector2(positionLeftButtonList[i], cookB.GetComponent<RectTransform>().offsetMin.y);
                    cookB.SetActive(true);
                    break;
                case "boil":
                    boilB.GetComponent<RectTransform>().offsetMax = new Vector2(-positionRightButtonList[i], boilB.GetComponent<RectTransform>().offsetMax.y);
                    boilB.GetComponent<RectTransform>().offsetMin = new Vector2(positionLeftButtonList[i], boilB.GetComponent<RectTransform>().offsetMin.y);
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
        ThumbnailManager.instance.isTransit = true;
        StartCoroutine("WaitTransition");
    }

    IEnumerator WaitTransition()
    {
        yield return new WaitForSeconds(1f);
        ThumbnailManager.instance.isTransit = false;
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
        if (isInfinite)
        {
            if (PlayerPrefs.GetInt("floorReached") < gameObject.GetComponent<InfiniteLevel>().nbFloor)
            {
                PlayerPrefs.SetInt("floorReached", gameObject.GetComponent<InfiniteLevel>().nbFloor);
            }

            gameObject.GetComponent<InfiniteLevel>().bestScore.text = PlayerPrefs.GetInt("floorReached").ToString();
            gameObject.GetComponent<InfiniteLevel>().actualScore.text = gameObject.GetComponent<InfiniteLevel>().nbFloor.ToString();
            Time.timeScale = 0f;
            scoreScreen.SetActive(true);
            scoreScreen.transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 0f;
            scoreScreen.SetActive(true);
            scoreScreen.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void PlayerWin()
    {
        //Time.timeScale = 0f;
        scoreScreen.SetActive(true);
        scoreScreen.GetComponent<VictoryStars>().SetStars(GameManager.instance.GetPlayerLife());
        bottomScreen.transform.parent.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;

        PlayerPrefs.SetInt("starLevel" + UIManager.chosenLevel.ToString(), scoreScreen.GetComponent<VictoryStars>().nbStars);
        scoreScreen.transform.GetChild(0).gameObject.SetActive(true);
    }
}
