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
        PlayerPrefs.SetInt("level", 6);
        PlayerPrefs.SetInt("starLevel1", 3);
        PlayerPrefs.SetInt("starLevel2", 3);
        PlayerPrefs.SetInt("starLevel3", 3);
        PlayerPrefs.SetInt("starLevel4", 3);
        PlayerPrefs.SetInt("starLevel5", 3);

        Application.Quit();
    }

    public void ResetSave()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
