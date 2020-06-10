using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterNbKO : MonoBehaviour
{
    [SerializeField] string token;

    void Start()
    {
        int currentNb = PlayerPrefs.GetInt(token);

        GetComponent<Text>().text = currentNb.ToString();
    }
}
