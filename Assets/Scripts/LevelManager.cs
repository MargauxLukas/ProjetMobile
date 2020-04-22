using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Transform bin;

    public GameObject topScreen;

    public GameObject kneadB;
    public GameObject cutB;
    public GameObject whipB;
    public GameObject cookB;

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
        Debug.Log(i);
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
                    currentLevel.Add(go);
                }
                break;
            case 4:
                foreach (GameObject go in level4)
                {
                    currentLevel.Add(go);
                }
                break;
            case 5:
                foreach (GameObject go in level5)
                {
                    cookB.transform.position = kneadB.transform.position;
                    kneadB.gameObject.SetActive(false);
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
        if (currentLevel.Count != 0)
        {
            GameObject monster = Instantiate(currentLevel[0], topScreen.transform);
            FightManager.instance.percentLife = monster.transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Life>().lifeMax * FightManager.instance.percentFight;
            FightManager.instance.ChoosePatterns();
            monster.transform.parent = topScreen.transform;
            gameObject.GetComponent<ButtonsManager>().tm = monster.transform.GetChild(3).GetComponent<ThumbnailManager>();
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
        BeginGame();
        ActivatePhase1();
    }

    public void ActivatePhase1()
    {
        phase1Buttons.SetActive(true);
        phase2Buttons.SetActive(false);
    }

    public void ActivatePhase2()
    {
        phase1Buttons.SetActive(false);
        phase2Buttons.SetActive(true);
    }

    public void GoToBin(GameObject go)
    {
        go.transform.SetParent(bin.transform);
    }
}
