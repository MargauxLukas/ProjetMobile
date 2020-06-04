using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionUnlock : MonoBehaviour
{
    [SerializeField] string tokenKey;

    void Start()
    {
        int nbDefeat = PlayerPrefs.GetInt(tokenKey);
        //Debug.Log(currentLevel + " >= " + levelRequirement);
        if (nbDefeat > 0)
        {
            GetComponent<Button>().interactable = true;
            transform.GetChild(0).GetComponent<Image>().color = new Color32(255,255,255,255);
        }
    }
}
