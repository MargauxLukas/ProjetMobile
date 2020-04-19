using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    public static Wallet instance;
    public int tokens = 0;

    private void Start()
    {
        if(instance = null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this);
        UpdateWallet();
    }

    private void Update()
    {
        Debug.Log("Update");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Loaded : " + scene.name);
        Debug.Log(mode);

        if (scene.buildIndex == 0)
        {
            UpdateWallet();
        }
    }

    void UpdateWallet()
    {
        Debug.Log("Wallet");
        GameObject tokensText = GameObject.FindGameObjectWithTag("Tokens");
        Debug.Log(tokensText.name);

        if(tokens >= 999)
        {
            tokens = 999;
        }

        tokensText.GetComponent<Text>().text = tokens.ToString();
        Debug.Log(tokensText.GetComponent<Text>().text);
    }
}
