using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsList : MonoBehaviour
{
    public Material defaultMat;
    public Material easyMat;
    public Material mediumMat;
    public Material hardMat;

    private int layoutNumber = 0;

    public void IncreaseNumber()
    {
        if (layoutNumber < 5)
        {
            transform.GetChild(layoutNumber).gameObject.SetActive(false);
            layoutNumber++;
            ActivateGood();
        }
    }

    public void DecreaseNumber()
    {
        if (layoutNumber > 0)
        {
            transform.GetChild(layoutNumber).gameObject.SetActive(true);
            layoutNumber--;
            ActivateGood();
        }
    }

    public void ActivateGood()
    {
        transform.GetChild(layoutNumber).gameObject.SetActive(true);
    }
}
