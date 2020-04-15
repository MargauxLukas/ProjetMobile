using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static int level = 0;

    public void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void SelectLevel(int levelNum)
    {
        level = levelNum;
        SceneManager.LoadScene(1);
    }
}
