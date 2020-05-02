using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockLevel : MonoBehaviour
{
    [SerializeField] int levelRequirement;
    // Start is called before the first frame update
    void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("level");

        if(currentLevel >= levelRequirement)
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
