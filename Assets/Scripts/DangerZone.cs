using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DangerZone : MonoBehaviour
{
    public InputField field;
    private string code = "UNLOCKALL";

    public void VerifyCode()
    {
        if (field.text.ToUpper() == code)
        {
            UnlockAll();
        }
    }

    void UnlockAll()
    {
        PlayerPrefs.SetInt("level", 21);
        PlayerPrefs.SetInt("starLevel1", 3);
        PlayerPrefs.SetInt("starLevel2", 3);
        PlayerPrefs.SetInt("starLevel3", 3);
        PlayerPrefs.SetInt("starLevel4", 3);
        PlayerPrefs.SetInt("starLevel5", 3);
        PlayerPrefs.SetInt("starLevel6", 3);
        PlayerPrefs.SetInt("starLevel7", 3);
        PlayerPrefs.SetInt("starLevel8", 3);
        PlayerPrefs.SetInt("starLevel9", 3);
        PlayerPrefs.SetInt("starLevel10", 3);
        PlayerPrefs.SetInt("starLevel11", 3);
        PlayerPrefs.SetInt("starLevel12", 3);
        PlayerPrefs.SetInt("starLevel13", 3);
        PlayerPrefs.SetInt("starLevel14", 3);
        PlayerPrefs.SetInt("starLevel15", 3);
        PlayerPrefs.SetInt("starLevel16", 3);
        PlayerPrefs.SetInt("starLevel17", 3);
        PlayerPrefs.SetInt("starLevel18", 3);
        PlayerPrefs.SetInt("starLevel19", 3);
        PlayerPrefs.SetInt("starLevel20", 3);
        PlayerPrefs.SetInt("starLevel21", 3);

        Application.Quit();
    }

    public void ResetSave()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
