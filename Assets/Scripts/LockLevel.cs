using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockLevel : MonoBehaviour
{
    [SerializeField] int levelRequirement;

    [Header("Level Detail Menu < Layout Group < Layout")]
    public GameObject Layout;
    // Start is called before the first frame update
    void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("level");
        //Debug.Log(currentLevel + " >= " + levelRequirement);
        if (currentLevel >= levelRequirement)
        {
            GetComponent<Button>().interactable = true;
        }
    }

    public void UnlockDifficulty()
    {
        if(PlayerPrefs.GetInt("starLevel" + levelRequirement.ToString() + "Noob") > 0)
        {
            Layout.transform.GetChild(0).GetComponent<Toggle>().interactable = true;
            Layout.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            Layout.transform.GetChild(0).GetComponent<Toggle>().interactable = false;
            Layout.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        }


        if (PlayerPrefs.GetInt("starLevel" + levelRequirement.ToString() + "Easy") > 0)
        {
            Layout.transform.GetChild(1).GetComponent<Toggle>().interactable = true;
            Layout.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            Layout.transform.GetChild(1).GetComponent<Toggle>().interactable = false;
            Layout.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("starLevel" + levelRequirement.ToString() + "Medium") > 0)
        {
            Layout.transform.GetChild(2).GetComponent<Toggle>().interactable = true;
            Layout.transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            Layout.transform.GetChild(2).GetComponent<Toggle>().interactable = false;
            Layout.transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
        }
    }
}
