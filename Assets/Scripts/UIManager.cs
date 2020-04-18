using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static int chosenLevel;

    public void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void SelectLevel(int levelNum)
    {
        chosenLevel = levelNum;
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
