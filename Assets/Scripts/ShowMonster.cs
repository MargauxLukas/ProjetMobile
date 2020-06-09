using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMonster : MonoBehaviour
{
    [SerializeField] int levelRequirement;

    void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("level");
        //Debug.Log(currentLevel + " >= " + levelRequirement);
        if (currentLevel >= levelRequirement)
        {
            GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
}
