using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameObject player;

    [Header("Canvas > Bin")]
    public Transform bin;

    [Header("TopScreenOutUI")]
    public Transform monsterParent;

    [Header("Canvas Screens")]
    public GameObject topScreen;
    public GameObject bottomScreen;
    public GameObject endScreen;
    public GameObject scoreScreen;
    public GameObject infiniteScreen;

    [Header("Canvas > BottomScreen > Button Area > Phase1 Button && Phase2 Button")]
    public GameObject phase1Buttons;
    public GameObject phase2Buttons;

    private GameObject kneadB;
    private GameObject cutB;
    private GameObject whipB;
    private GameObject cookB;
    private GameObject boilB;

    private GameObject attackB;
    private GameObject defendB;
    private GameObject eatB;
    private GameObject pauseB;

    [Header("Crumb")]
    public List<GameObject> obstacles;

    private List<float> positionLeftButtonList = new List<float> {32, 260, 485 };
    private List<float> positionRightButtonList = new List<float> {480, 254, 26 };

    [Header("Levels")]
    public bool isInfinite = false;
    public List<GameObject> level1;
    public List<GameObject> level2;
    public List<GameObject> level3;
    public List<GameObject> level4;
    public List<GameObject> level5;
    public List<GameObject> level6;
    public List<GameObject> level7;
    public List<GameObject> level8;
    public List<GameObject> level9;
    public List<GameObject> level10;
    public List<GameObject> level11;
    public List<GameObject> level12;
    public List<GameObject> level13;
    public List<GameObject> level14;
    public List<GameObject> level15;
    public List<GameObject> level16;
    public List<GameObject> level17;
    public List<GameObject> level18;
    public List<GameObject> level19;
    public List<GameObject> level20;

    public List<GameObject> currentLevel;

    private bool isLevel1 = false;

    public bool level1Tuto = false;
    public bool level2Tuto = false;
    public bool level4Tuto = false;
    public bool level6Tuto = false;
    public bool level8Tuto = false;
    public bool level11Tuto = false;
    public bool level13Tuto = false;

    private int countMonster;                       

    [Header("Transition Text")]
    public GameObject beginTextGameObject;
    public GameObject eatItTextGameObject;

    [Header("Particle GameObject")]
    public GameObject particle;
    public GameObject cookieVFX;
    public GameObject eatVFX;
    public GameObject defendVFX;
    public GameObject attackVFX;

    [Header("Background Sprite")]
    public Sprite fridge1;
    public Sprite fridge2;
    public Sprite candy1;
    public Sprite candy2;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        boilB  = phase2Buttons.transform.GetChild(0).gameObject;
        whipB  = phase2Buttons.transform.GetChild(1).gameObject;
        kneadB = phase2Buttons.transform.GetChild(2).gameObject;
        cutB   = phase2Buttons.transform.GetChild(3).gameObject;
        cookB  = phase2Buttons.transform.GetChild(4).gameObject;

        attackB = phase1Buttons.transform.GetChild(0).gameObject;
        defendB = phase1Buttons.transform.GetChild(1).gameObject;

        eatB = phase1Buttons.transform.parent.transform.GetChild(0).GetChild(0).gameObject;
        pauseB = phase1Buttons.transform.parent.transform.GetChild(0).GetChild(1).gameObject;

        ChooseLevel(UIManager.chosenLevel);
    }

    public void ChooseLevel(int i)
    {
        switch (i)
        {
            case 1:
                foreach (GameObject go in level1)
                {
                    currentLevel.Add(go);
                }
                cutB.transform.position = whipB.transform.position;
                whipB.gameObject.SetActive(false);
                isLevel1 = true;
                countMonster = level1.Count;

                if(PlayerPrefs.GetInt("level1Tuto") == 0)
                {
                    level1Tuto = true;
                }

                break;
            case 2:
                foreach (GameObject go in level2)
                {
                    currentLevel.Add(go);
                }
                countMonster = level2.Count;
                monsterParent.parent.GetComponent<SpriteRenderer>().sprite = candy1;

                if (PlayerPrefs.GetInt("level2Tuto") == 0)
                {
                    level2Tuto = true;
                }
                break;
            case 3:
                foreach (GameObject go in level3)
                {
                    currentLevel.Add(go);
                }
                cookB.transform.position = whipB.transform.position;
                whipB.gameObject.SetActive(false);
                countMonster = level3.Count;
                break;
            case 4:
                foreach (GameObject go in level4)
                {
                    currentLevel.Add(go);
                }
                countMonster = level4.Count;
                monsterParent.parent.GetComponent<SpriteRenderer>().sprite = candy1;

                if (PlayerPrefs.GetInt("level4Tuto") == 0)
                {
                    level4Tuto = true;
                }
                break;
            case 5:
                foreach (GameObject go in level5)
                {
                    currentLevel.Add(go);
                }
                boilB.transform.position = whipB.transform.position;
                whipB.gameObject.SetActive(false);
                countMonster = level5.Count;
                monsterParent.parent.GetComponent<SpriteRenderer>().sprite = fridge2;
                break;
            case 6:
                foreach (GameObject go in level6)
                {
                    currentLevel.Add(go);
                }
                countMonster = level6.Count;

                if (PlayerPrefs.GetInt("level6Tuto") == 0)
                {
                    level6Tuto = true;
                }
                monsterParent.parent.GetComponent<SpriteRenderer>().sprite = candy1;
                break;
            case 7:
                foreach (GameObject go in level7)
                {
                    currentLevel.Add(go);
                }
                countMonster = level7.Count;
                monsterParent.parent.GetComponent<SpriteRenderer>().sprite = candy2;
                break;
            case 8:
                foreach (GameObject go in level8)
                {
                    currentLevel.Add(go);
                }
                boilB.transform.position = cutB.transform.position;
                cookB.transform.position = whipB.transform.position;
                whipB.gameObject.SetActive(false);
                cutB.gameObject.SetActive(false);
                monsterParent.parent.GetComponent<SpriteRenderer>().sprite = fridge2;

                if (PlayerPrefs.GetInt("level8Tuto") == 0)
                {
                    level8Tuto = true;
                }

                countMonster = level8.Count;
                break;
            case 9:
                foreach (GameObject go in level9)
                {
                    currentLevel.Add(go);
                }
                cookB.transform.position = whipB.transform.position;
                whipB.gameObject.SetActive(false);
                monsterParent.parent.GetComponent<SpriteRenderer>().sprite = fridge1;

                countMonster = level9.Count;
                break;
            case 10:
                foreach (GameObject go in level10)
                {
                    currentLevel.Add(go);
                }
                countMonster = level10.Count;
                monsterParent.parent.GetComponent<SpriteRenderer>().sprite = fridge2;
                break;
            case 11:
                foreach (GameObject go in level11)
                {
                    currentLevel.Add(go);
                }
                boilB.transform.position = whipB.transform.position;
                whipB.gameObject.SetActive(false);
                monsterParent.parent.GetComponent<SpriteRenderer>().sprite = candy1;

                if (PlayerPrefs.GetInt("level11Tuto") == 0)
                {
                    level11Tuto = true;
                }
                countMonster = level11.Count;
                break;
            case 12:
                foreach (GameObject go in level12)
                {
                    currentLevel.Add(go);
                }
                countMonster = level12.Count;
                monsterParent.parent.GetComponent<SpriteRenderer>().sprite = fridge2;
                break;
            case 13:
                foreach (GameObject go in level13)
                {
                    currentLevel.Add(go);
                }

                if (PlayerPrefs.GetInt("level13Tuto") == 0)
                {
                    level13Tuto = true;
                }
                countMonster = level13.Count;
                monsterParent.parent.GetComponent<SpriteRenderer>().sprite = fridge2;
                break;
            case 14:
                foreach (GameObject go in level14)
                {
                    currentLevel.Add(go);
                }
                cookB.transform.position = kneadB.transform.position;
                kneadB.SetActive(false);
                countMonster = level14.Count;
                monsterParent.parent.GetComponent<SpriteRenderer>().sprite = fridge2;
                break;
            case 15:
                foreach (GameObject go in level15)
                {
                    currentLevel.Add(go);
                }
                boilB.transform.position = kneadB.transform.position;
                cookB.transform.position = whipB.transform.position;
                kneadB.SetActive(false);
                whipB.SetActive(false);

                countMonster = level15.Count;
                monsterParent.parent.GetComponent<SpriteRenderer>().sprite = candy2;
                break;
            case 16:
                foreach (GameObject go in level16)
                {
                    currentLevel.Add(go);
                }
                countMonster = level16.Count;
                monsterParent.parent.GetComponent<SpriteRenderer>().sprite = fridge1;
                break;
            case 17:
                foreach (GameObject go in level17)
                {
                    currentLevel.Add(go);
                }
                countMonster = level17.Count;
                monsterParent.parent.GetComponent<SpriteRenderer>().sprite = candy2;
                break;
            case 18:
                foreach (GameObject go in level18)
                {
                    currentLevel.Add(go);
                }
                boilB.transform.position = kneadB.transform.position;
                cookB.transform.position = whipB.transform.position;
                kneadB.SetActive(false);
                whipB.SetActive(false);

                countMonster = level18.Count;
                monsterParent.parent.GetComponent<SpriteRenderer>().sprite = fridge2;
                break;
            case 19:
                foreach (GameObject go in level19)
                {
                    currentLevel.Add(go);
                }

                boilB.transform.position = kneadB.transform.position;
                kneadB.SetActive(false);

                countMonster = level19.Count;
                monsterParent.parent.GetComponent<SpriteRenderer>().sprite = fridge2;
                break;
            case 20:
                foreach (GameObject go in level20)
                {
                    currentLevel.Add(go);
                }
                cookB.transform.position = whipB.transform.position;
                whipB.SetActive(false);

                countMonster = level20.Count;
                monsterParent.parent.GetComponent<SpriteRenderer>().sprite = fridge1;
                break;
            case 21:
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
        if(currentLevel.Count == 1 && !isInfinite && !isLevel1)
        {
            bottomScreen.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
            endScreen.SetActive(true);                                          

            GameObject monster = Instantiate(currentLevel[0], topScreen.transform);
            monster.transform.GetChild(3).gameObject.transform.position = new Vector3(0f, 0.47f, -2f);
            monster.transform.GetChild(3).gameObject.transform.SetParent(monsterParent);

            Time.timeScale = 0f;
            eatItTextGameObject.SetActive(true);
            eatItTextGameObject.transform.GetChild(2).GetComponent<Animator>().SetBool("isBegin", true);
            StartCoroutine("WaitAnimationEat");
        }
        else if (currentLevel.Count != 0 || isLevel1)
        {
            GameObject monster = Instantiate(currentLevel[0], topScreen.transform);
            TapisManager.instance.TapisOnPhase1();
            monster.transform.GetChild(2).gameObject.transform.position = new Vector3(0f, 0.5f, -2f);
            monster.transform.GetChild(2).gameObject.transform.SetParent(monsterParent);
            FightManager.instance.percentLife = monster.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Life>().lifeMax * FightManager.instance.percentFight;
            FightManager.instance.timerAttack = 1.5f;
            FightManager.instance.isMonsterAttacking = false;
            FightManager.instance.SetLifeGoal();
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
        UninteractableButtons();
        yield return new WaitForSecondsRealtime(1.333f);
        InteractableButtons();
        Time.timeScale = 1f;
        Destroy(beginTextGameObject.gameObject);

        if(level1Tuto)
        {
            TutorialManager.instance.Level1Begin();
        }
        else if(level2Tuto)
        {
            TutorialManager.instance.Level2Begin();
        }
    }

    IEnumerator WaitAnimationEat()
    {
        yield return new WaitForSecondsRealtime(1.333f);
        Time.timeScale = 1f;
        Destroy(eatItTextGameObject.gameObject);

        if(level2Tuto)
        {
            TutorialManager.instance.Level2FinalDish();
        }
    }

    public void UninteractableButtons()
    {
        attackB.GetComponent<Button>().interactable = false;
        defendB.GetComponent<Button>().interactable = false;
        eatB   .GetComponent<Button>().interactable = false;
        cutB.GetComponent<Button>().interactable = false;
        kneadB.GetComponent<Button>().interactable = false;
        whipB.GetComponent<Button>().interactable = false;
        boilB.GetComponent<Button>().interactable = false;
        cookB.GetComponent<Button>().interactable = false;
        pauseB.GetComponent<Button>().interactable = false;
    }

    public void InteractableButtons()
    {
        attackB.GetComponent<Button>().interactable = true;
        defendB.GetComponent<Button>().interactable = true;
        eatB   .GetComponent<Button>().interactable = true;
        cutB.GetComponent<Button>().interactable = true;
        kneadB.GetComponent<Button>().interactable = true;
        whipB.GetComponent<Button>().interactable = true;
        boilB.GetComponent<Button>().interactable = true;
        cookB.GetComponent<Button>().interactable = true;
        pauseB.GetComponent<Button>().interactable = true;
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
        particle.transform.GetChild(0).gameObject.SetActive(true);
        scoreScreen.SetActive(true);
        scoreScreen.GetComponent<VictoryStars>().SetStars(GameManager.instance.GetPlayerLife());
        bottomScreen.transform.parent.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;

        PlayerPrefs.SetInt("starLevel" + UIManager.chosenLevel.ToString(), scoreScreen.GetComponent<VictoryStars>().nbStars);
        PlayerPrefs.SetInt("level" + UIManager.chosenLevel.ToString() + "Tuto", 1);
        scoreScreen.transform.GetChild(0).gameObject.SetActive(true);

        Time.timeScale = 0f;
    }
}
