using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;
    public TextMeshProUGUI tutorialText;
    public GameObject tutoGo;
    public TMP_SpriteAsset attack;
    public TMP_SpriteAsset defend;
    public TMP_SpriteAsset eat;
    public TMP_SpriteAsset cut;
    public TMP_SpriteAsset knead;
    public TMP_SpriteAsset whip;
    public TMP_SpriteAsset boil;
    public TMP_SpriteAsset cook;

    private bool isFirstAttack = true;
    private bool isFirstShield = true;
    private bool isFirstCut = true;
    private bool isFirstKnead = true;
    private bool isFirstWhip = true;
    private bool isFirstBoil = true;
    private bool isFirstCook = true;
    private bool isFirstLock = true;
    private bool isFirstCandy = true;

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
    }
    #endregion

    #region Level 1
    public void Level1Begin()
    {
        Time.timeScale = 0f;
        tutorialText.spriteAsset = attack;
        tutorialText.text = "This bread wants to fight !\nJust Beat it down with : <sprite=0>";
        ActivateText();
    }

    public void Level1FirstEnnemyAttack()
    {
        if (isFirstAttack)
        {
            Time.timeScale = 0f;
            tutorialText.spriteAsset = defend;
            tutorialText.text = "Look out! It's ready to punch you. Protect yourself with <sprite=0> to avoid taking damages.";
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
        tutorialText.spriteAsset = eat;
        tutorialText.text = "Hey ! Nice one ! Now eat it with : <sprite=0>";
        ActivateText();
    }

    #endregion

    #region Level 4
    public void Level4FirstShield()
    {
        if (isFirstShield)
        {
            Time.timeScale = 0f;
            tutorialText.spriteAsset = eat;
            tutorialText.text = "Look, it's protecting itself. I think you can break its shield by eating it with : <sprite=0>";
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
            tutorialText.spriteAsset = cut;
            tutorialText.text = "The next thumbnail is a special one. To perfectly cut the ingredient, you'll have to rapidly press : <sprite=0>";
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
            tutorialText.spriteAsset = knead;
            tutorialText.text = "The next one is an other special thumbnail, you will have to press <sprite=0> with two fingers to perform the right action.";
            ActivateText();
            isFirstKnead = false;
        }
    }

    public void Level6SpecialWhip()
    {
        if (isFirstWhip)
        {
            Time.timeScale = 0f;
            tutorialText.spriteAsset = whip;
            tutorialText.text = "Another special thumnail is coming. For this one you'll need to swipe down with your finger while pressing <sprite=0>";
            ActivateText();
            isFirstWhip = false;
        }
    }
    #endregion

    #region Level 8
    public void Level8SpecialBoil()
    {
        if (isFirstBoil)
        {
            Time.timeScale = 0f;
            tutorialText.spriteAsset = boil;
            tutorialText.text = "To achieve a perfect action on a boiling thumbnail, you'll have to swipe up with your finger while pressing <sprite=0>";
            ActivateText();
            isFirstBoil = false;
        }
    }

    public void Level8SpecialCook()
    {
        if (isFirstCook)
        {
            Time.timeScale = 0f;
            tutorialText.lineSpacing = 1.5f;
            tutorialText.spriteAsset = cook;
            tutorialText.text = "Here comes a special cooking thumbnail. For this one, you will have to maintain the pressure on <sprite=0> until the sliding bar is full. ";
            ActivateText();
            isFirstCook = false;
        }
    }
    #endregion

    #region Level 11
    public void Level11FirstLock()
    {
        if (isFirstLock)
        {
            Time.timeScale = 0f;
            tutorialText.text = "Look, this thumbnail is locked, try to achieve the action linked to the next thumbnail to unlock the first one.";
            ActivateText();
            isFirstLock = false;
        }
    }
    #endregion

    #region Level 13
    public void Level13FirstCandy()
    {
        if (isFirstCandy)
        {
            Time.timeScale = 0f;
            tutorialText.spriteAsset = eat;
            tutorialText.text = "Uh oh, you let some crumbs escape while eating the ennemy's shield. Now they're hiding some thumbnails. Hit   <sprite=0> to eat the crumbs !";
            ActivateText();
            isFirstCandy = false;
        }
    }
    #endregion
}
