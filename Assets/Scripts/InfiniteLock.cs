using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteLock : MonoBehaviour
{
    [SerializeField] int starsLevel1Requirement;
    [SerializeField] int starsLevel2Requirement;
    [SerializeField] int starsLevel3Requirement;
    [SerializeField] int starsLevel4Requirement;
    [SerializeField] int starsLevel5Requirement;

    void Start()
    {
        int stars1 = PlayerPrefs.GetInt("starLevel1");
        int stars2 = PlayerPrefs.GetInt("starLevel2");
        int stars3 = PlayerPrefs.GetInt("starLevel3");
        int stars4 = PlayerPrefs.GetInt("starLevel4");
        int stars5 = PlayerPrefs.GetInt("starLevel5");
        //Debug.Log(currentLevel + " >= " + levelRequirement);
        if (stars1 == starsLevel1Requirement && stars2 == starsLevel2Requirement && stars3 == starsLevel3Requirement && stars4 == starsLevel4Requirement && stars5 == starsLevel5Requirement)
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
