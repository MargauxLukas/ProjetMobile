using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalLife : MonoBehaviour
{
    public int lifeMax = 10;
    public int currentLife = 10;
    public float nb;

    public Image life;


    public void Damage()
    {
        currentLife--;
        nb = 1 / (float)lifeMax;
        life.fillAmount = nb * currentLife;

        if (currentLife == 0)
        {
            ReturnToMenu();
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
