using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyNameUpdate : MonoBehaviour
{
    public static EnemyNameUpdate instance;
    public string bronzeName;
    public string argentName;
    public string orName;

    private void Awake()
    {
        instance = this;
    }

    public void ChangeNameEasy(string name)
    {
        gameObject.GetComponent<Text>().text = bronzeName;
    }

    public void ChangeNameMedium(string name)
    {
        gameObject.GetComponent<Text>().text = argentName;
    }

    public void ChangeNameHard(string name)
    {
        gameObject.GetComponent<Text>().text = orName;
    }
}
