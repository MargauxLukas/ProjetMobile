using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public int chosenLevel;

    public void SelectLevel(int levelNum)
    {
        chosenLevel = levelNum;
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
        //affect chosenLevel à qqch pour qu'il load le bon level
    }

    public void Quit()
    {
        Application.Quit();
    }
}
