using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolsHeader : MonoBehaviour
{
    public Color32 color;
    public Color32 white = new Color32(255, 255, 255, 255);
    [SerializeField] int levelRequirement;

    private void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("level");

        //Debug.Log(currentLevel + " >= " + levelRequirement);
        if (currentLevel >= levelRequirement)
        {
            GetComponent<Image>().color = color;
        }
    }
}
