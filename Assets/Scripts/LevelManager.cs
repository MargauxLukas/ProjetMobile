using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public GameObject topScreen;

    public List<GameObject> level1;
    public List<GameObject> level2;
    public List<GameObject> level3;
    public List<GameObject> level4;
    public List<GameObject> level5;

    public List<GameObject> currentLevel;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ChooseLevel(UIManager.level);
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
                break;
            case 2:
                foreach (GameObject go in level2)
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
        GameObject monster = Instantiate(currentLevel[0], topScreen.transform);
        monster.transform.parent = topScreen.transform;
        gameObject.GetComponent<ButtonsManager>().tm = monster.transform.GetChild(3).GetComponent<ThumbnailManager>();
    }

    public void NextMonster()
    {
        currentLevel.RemoveAt(0);
        Destroy(topScreen.transform.GetChild(0).gameObject);
        BeginGame();
    }
}
