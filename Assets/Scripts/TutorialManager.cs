using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;
    public Text tutorialText;
    public GameObject tutoGo;

    private bool isFirstAttack = true;
    private bool isFirstShield = true;
    private bool isFirstCut = true;
    private bool isFirstKnead = true;
    private bool isFirstWhip = true;

    public void Awake()
    {
        instance = this;
    }

    #region commun
    public void ActivateText()
    {
        LevelManager.instance.UninteractableButtons();
        tutoGo.SetActive(true);
    }

    public void DesactivateText()
    {
        Time.timeScale = 1f;
        LevelManager.instance.InteractableButtons();
        tutoGo.SetActive(false);
        tutorialText.lineSpacing = 1f;

        tutoGo.transform.GetChild(2).gameObject.SetActive(false);
        tutoGo.transform.GetChild(3).gameObject.SetActive(false);
        tutoGo.transform.GetChild(4).gameObject.SetActive(false);
        tutoGo.transform.GetChild(5).gameObject.SetActive(false);
        tutoGo.transform.GetChild(6).gameObject.SetActive(false);
        tutoGo.transform.GetChild(7).gameObject.SetActive(false);
        tutoGo.transform.GetChild(8).gameObject.SetActive(false);
    }
    #endregion

    #region Level 1
    public void Level1Begin()
    {
        Time.timeScale = 0f;
        tutorialText.text = "This bread wants to fight !\nJust Beat it down with :";
        tutoGo.transform.GetChild(2).gameObject.SetActive(true);
        ActivateText();
    }

    public void Level1FirstEnnemyAttack()
    {
        if (isFirstAttack)
        {
            Time.timeScale = 0f;
            tutorialText.text = "Look out! It's ready to punch you. Protect yourself with       to avoid taking damages.";
            tutoGo.transform.GetChild(3).gameObject.SetActive(true);
            ActivateText();
            isFirstAttack = false;
        }
    }

    #endregion

    #region Level 2
    public void Level2Begin()
    {
        Time.timeScale = 0f;
        tutorialText.text = "Here's an other one coming. Just struck it down as you did before !";
        ActivateText();
    }

    public void Level2Stunned()
    {
        Time.timeScale = 0f;
        tutorialText.text = "Did you ever thought about eating those mobsters' hordes ? Here is some tools. Try to cook up a good dish by hitting the right buttons, according to the thumbnails on the conveyor.";
        ActivateText();
    }

    public void Level2FinalDish()
    {
        Time.timeScale = 0f;
        tutorialText.text = "Hey ! Nice one ! Now eat it with :\n";
        tutoGo.transform.GetChild(4).gameObject.SetActive(true);
        ActivateText();
    }

    #endregion

    #region Level 4
    public void Level4FirstShield()
    {
        if (isFirstShield)
        {
            Time.timeScale = 0f;
            tutorialText.text = "Look, it's protecting itself. I think you can break its shield by eating it with :\n";
            tutoGo.transform.GetChild(5).gameObject.SetActive(true);
            ActivateText();
            isFirstShield = false;
        }
    }
    #endregion

    #region Level 6
    public void Level6SpecialCut()
    {
        if (isFirstCut)
        {
            Time.timeScale = 0f;
            tutorialText.text = "The next thumbnail is a special one. To perfectly cut the ingredient, you'll have to rapidly press :";
            tutoGo.transform.GetChild(6).gameObject.SetActive(true);
            ActivateText();
            isFirstCut = false;
        }
    }

    public void Level6SpecialKnead()
    {
        if (isFirstKnead)
        {
            Time.timeScale = 0f;
            tutorialText.lineSpacing = 1.5f;
            tutorialText.text = "The next one is an other special thumbnail, you will have to press       with two fingers to perform the right action.";
            tutoGo.transform.GetChild(7).gameObject.SetActive(true);
            ActivateText();
            isFirstKnead = false;
        }
    }

    public void Level6SpecialWhip()
    {
        if (isFirstWhip)
        {
            Time.timeScale = 0f;
            tutorialText.text = "Another special thumnail is coming. For this one you'll need to swipe down with your finger while pressing ";
            tutoGo.transform.GetChild(8).gameObject.SetActive(true);
            ActivateText();
            isFirstWhip = false;
        }
    }
    #endregion
}
