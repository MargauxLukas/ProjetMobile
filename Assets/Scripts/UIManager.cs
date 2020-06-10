using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance ;
    public AudioClip combatMusic;
    public AudioClip bossTheme;
    public AudioClip MenuMusic;
    public AudioClip confectionMusic;
    public static int chosenLevel;
    public static string difficulty = "Noob";

    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public void SelectLevel(int levelNum)
    {
        chosenLevel = levelNum;
    }

    public void Play()
    {
        gameObject.GetComponent<AudioSource>().clip = combatMusic;
        gameObject.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(1);
    }

    public void PlayBossMusic()
    {
        gameObject.GetComponent<AudioSource>().clip = bossTheme;
        gameObject.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(1);
    }

    public void SwitchMusicToCombat()
    {
        gameObject.GetComponent<AudioSource>().clip = combatMusic;
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void SwitchMusicToPreparation()
    {
        gameObject.GetComponent<AudioSource>().clip = confectionMusic;
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PlayMusic(AudioClip ac)
    {
        Player.instance.GetComponent<AudioSource>().clip = ac;
        Player.instance.GetComponent<AudioSource>().Play();
    }

    public void StopMusic()
    {
        gameObject.GetComponent<AudioSource>().Stop();
    }

    public void SetEasy(GameObject go)
    {
        if (go.GetComponent<Toggle>().isOn)
        {
            difficulty = "Easy";
            AllTexts.instance.SetStarsEasy();
            go.transform.parent.transform.GetChild(1).GetComponent<Toggle>().isOn = false;
            go.transform.parent.transform.GetChild(2).GetComponent<Toggle>().isOn = false;
        }
        else
        {
            difficulty = "Noob";
            AllTexts.instance.SetStarsNoob();
        }
    }

    public void SetMedium(GameObject go)
    {
        if (go.GetComponent<Toggle>().isOn)
        {
            difficulty = "Medium";
            AllTexts.instance.SetStarsMedium();
            go.transform.parent.transform.GetChild(0).GetComponent<Toggle>().isOn = false;
            go.transform.parent.transform.GetChild(2).GetComponent<Toggle>().isOn = false;
        }
        else
        {
            difficulty = "Noob";
            AllTexts.instance.SetStarsNoob();
        }
    }

    public void SetHard(GameObject go)
    {
        if (go.GetComponent<Toggle>().isOn)
        {
            difficulty = "Hard";
            AllTexts.instance.SetStarsHard();
            go.transform.parent.transform.GetChild(0).GetComponent<Toggle>().isOn = false;
            go.transform.parent.transform.GetChild(1).GetComponent<Toggle>().isOn = false;
        }
        else
        {
            difficulty = "Noob";
            AllTexts.instance.SetStarsNoob();
        }
    }

    public void SetNoob()
    {
        difficulty = "Noob";
        AllTexts.instance.SetStarsNoob();
    }

    public void CheckIsOn(GameObject go)
    {
        if(!go.GetComponent<Toggle>().isOn)
        {
            difficulty = "Noob";
            AllTexts.instance.SetStarsNoob();
        }
    }
}
