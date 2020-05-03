using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    public Text text;
    public ThumbnailManager tm;

    public void Cut()
    {
        tm.CheckAction(3);
    }

    public void KneadDown()
    {
        tm.CheckAction(2);
        ThumbnailManager.instance.knead = true;
    }

    public void KneadUp()
    {
        ThumbnailManager.instance.knead = false;
    }

    public void CookDown()
    {
        tm.CheckAction(4);
        ThumbnailManager.instance.cook = true;
    }

    public void CookUp()
    {
        ThumbnailManager.instance.cook = false;
    }

    public void BoilDown()
    {
        tm.CheckAction(5);
        ThumbnailManager.instance.boil = true;
    }

    public void BoilUp()
    {

    }

    public void WhipDown()
    {
        tm.CheckAction(1);
        ThumbnailManager.instance.whip = true;
    }
    public void WhipUp()
    {
        Debug.Log("WhipUP");
    }


    public void Eat()
    {
        FightManager.instance.Eat();
    }

    public void EatFinal()
    {
        LevelManager.instance.topScreen.transform.GetChild(0).GetComponent<FinalLife>().Damage();
        ThumbnailManager.instance.Heal();
    }

    public void Attack()
    {
        FightManager.instance.Attack();
    }

    public void DefendDown()
    {
        FightManager.instance.Defend();
    }

    public void DefendUp()
    {
        FightManager.instance.DontDefend();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void PlayMusic(AudioClip ac)
    {
        Player.instance.GetComponent<AudioSource>().clip = ac;
        Player.instance.GetComponent<AudioSource>().Play();
    }
}
