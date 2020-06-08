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

    public void ChangeNameEasy(GameObject go)
    {
        go.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = bronzeName;
    }

    public void ChangeNameMedium(GameObject go)
    {
        go.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = argentName;
    }

    public void ChangeNameHard(GameObject go)
    {
        go.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = orName;
    }
}
