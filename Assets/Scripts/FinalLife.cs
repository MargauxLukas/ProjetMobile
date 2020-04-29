using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLife : MonoBehaviour
{
    public int lifeMax = 10;
    public int currentLife = 10;

    public void Damage()
    {
        currentLife--;

        if(currentLife == 0)
        {
            ReturnToMenu();
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
