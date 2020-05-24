using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    public ThumbnailManager tm;

    private FightManager fm;
    private LevelManager lm;
    private ShieldSlider ss;
    public GameObject slider;

    private void Start()
    {
        fm = FightManager.instance;
        lm = LevelManager.instance;
        ss = slider.GetComponent<ShieldSlider>();
    }

    public void Update()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    #region Cut
    public void Cut()
    {
        tm.CheckAction(3);
    }
    #endregion

    #region Knead
    public void KneadDown()
    {
        tm.CheckAction(2);
        ThumbnailManager.instance.knead = true;
    }

    public void KneadUp()
    {
        ThumbnailManager.instance.knead = false;
    }
    #endregion

    #region Cook
    public void CookDown()
    {
        tm.CheckAction(4);
        tm.cook = true;
    }

    public void CookUp()
    {
        tm.cook = false;
    }
    #endregion

    #region Boil
    public void BoilDown()
    {
        tm.CheckAction(5);
        tm.boil = true;
    }
    #endregion

    #region Whip
    public void WhipDown()
    {
        tm.CheckAction(1);
        tm.whip = true;
    }
    #endregion

    #region Eat
    public void EatDown()
    {
        if (tm.monsterLife.currentShield > 0)
        {
            slider.SetActive(true);
            ss.isMaintainEat = true;
        }
    }

    public void EatUp()
    {
        if (tm.monsterLife.currentShield > 0)
        {
            ss.isMaintainEat = false;
            ss.eatUp = true;
        }
    }

    public void EatFinalDown()
    {
        slider.SetActive(true);
        ss.isMaintainEat = true;

        /*lm.topScreen.transform.GetChild(0).GetComponent<FinalLife>().Damage();
        tm.Heal();*/
    }

    public void EatFinalUp()
    {
        ss.isMaintainEat = false;
        ss.eatUpFinal = true;
    }
    #endregion

    #region Attack & Defend
    public void Attack()
    {
        fm.Attack();
    }

    public void DefendDown()
    {
        fm.Defend();
    }

    public void DefendUp()
    {
        fm.DontDefend();
    }
    #endregion

    #region Pause
    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }
    #endregion

    #region Audio
    public void PlayMusic(AudioClip ac)
    {
        Player.instance.GetComponent<AudioSource>().clip = ac;
        Player.instance.GetComponent<AudioSource>().Play();
    }

    public void PlayNom()
    {
        int i = Random.Range(0, 6);
        Instantiate(EventSystem.current.currentSelectedGameObject.GetComponent<SFXList>().listAudio[i].gameObject, EventSystem.current.currentSelectedGameObject.GetComponent<SFXList>().parent);
    }

    public void PlayNomFinal()
    {
        if (lm.topScreen.transform.GetChild(0).GetComponent<FinalLife>().currentLife > 1)
        {
            int i = Random.Range(0, 6);
            Instantiate(EventSystem.current.currentSelectedGameObject.GetComponent<SFXList>().listAudio[i].gameObject, EventSystem.current.currentSelectedGameObject.GetComponent<SFXList>().parent);
        }
        else
        {
            Instantiate(EventSystem.current.currentSelectedGameObject.GetComponent<SFXList>().listAudio[6].gameObject, EventSystem.current.currentSelectedGameObject.GetComponent<SFXList>().parent);
        }
    }
    #endregion

    public void LoadLevelAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            UIManager.instance.gameObject.GetComponent<AudioSource>().clip = UIManager.instance.MenuMusic;
            UIManager.instance.gameObject.GetComponent<AudioSource>().Play();
            Time.timeScale = 1f;
            GameObject mainMenu = GameObject.FindGameObjectWithTag("MainMenu");
            GameObject lvlMenu = mainMenu.transform.parent.transform.GetChild(3).gameObject;
            lvlMenu.SetActive(true);
            mainMenu.SetActive(false);
        }
    }
}
