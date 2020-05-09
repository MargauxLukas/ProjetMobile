using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance ;
    public AudioClip sportTheme;
    public AudioClip MenuMusic;
    public static int chosenLevel;

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
        gameObject.GetComponent<AudioSource>().clip = sportTheme;
        gameObject.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(1);
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
}
