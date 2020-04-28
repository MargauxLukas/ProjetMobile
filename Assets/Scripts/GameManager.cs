using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Image lifeFill;

    public Text t1;
    public Text t2;
    public Text d1;
    public Text d2;

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
