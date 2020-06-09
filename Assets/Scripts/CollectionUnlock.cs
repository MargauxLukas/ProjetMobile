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

            if(tokenKey.Contains("Easy"))
            {
                transform.GetChild(0).GetComponent<Image>().material = transform.parent.parent.parent.gameObject.GetComponent<MaterialsList>().easyMat;
            }
            else if (tokenKey.Contains("Medium"))
            {
                transform.GetChild(0).GetComponent<Image>().material = transform.parent.parent.parent.gameObject.GetComponent<MaterialsList>().mediumMat;
            }
            else if (tokenKey.Contains("Hard"))
            {
                transform.GetChild(0).GetComponent<Image>().material = transform.parent.parent.parent.gameObject.GetComponent<MaterialsList>().hardMat;
            }
        }
        else
        {
            transform.GetChild(0).GetComponent<Image>().material = transform.parent.parent.parent.gameObject.GetComponent<MaterialsList>().defaultMat;
            transform.GetChild(0).GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        }
    }
}
