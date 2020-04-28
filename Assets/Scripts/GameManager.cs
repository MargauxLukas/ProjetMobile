using System.Collections;
using System.Collections.Generic;
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

        StartCoroutine(Life());
    }
}
