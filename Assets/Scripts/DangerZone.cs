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

        for(int i=1; i <= 21; i++)
        {
            PlayerPrefs.SetInt("starLevel" + i.ToString() + "Noob", 3);
            PlayerPrefs.SetInt("starLevel" + i.ToString() + "Easy", 3);
            PlayerPrefs.SetInt("starLevel" + i.ToString() + "Medium", 3);
            PlayerPrefs.SetInt("starLevel" + i.ToString() + "Hard", 3);
        }

        Application.Quit();
    }

    public void ResetSave()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
