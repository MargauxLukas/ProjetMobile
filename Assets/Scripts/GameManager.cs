using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Image lifeFill;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(Life());
    }

    IEnumerator Life()
    {
        yield return new WaitForSeconds(1f);
        lifeFill.fillAmount -= 0.02f;

        if(lifeFill.fillAmount == 0f)
        {
            LevelManager.instance.PlayerDeath();
        }

        StartCoroutine(Life());
    }

    public float GetPlayerLife()
    {
        return lifeFill.fillAmount;
    }
}
