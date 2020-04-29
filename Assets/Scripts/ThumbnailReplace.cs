using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThumbnailReplace : MonoBehaviour
{
    public static ThumbnailReplace instance;

    public List<Sprite> cutx2Image;
    public List<Sprite> cutx3Image;
    public List<Sprite> cutx4Image;

    public Sprite cutFinish;
    public Sprite kneadFinish;
    public Sprite kneadTwoTouchFinish;
    public Sprite whipFinish;
    public Sprite whipSwipeDownFinish;
    public Sprite cookFinish;
    public Sprite cookMaintainFinish;
    public Sprite boilFinish;
    public Sprite boilSwipeUpFinish;

    public int nbCut = 0;

    public void Awake()
    {
        instance = this;
    }

    public void ChooseCut(string name)
    {
        if(name.Contains("x2"))
        {
            Cutx2();
        }
        else if(name.Contains("x3"))
        {
            Cutx3();
        }
        else if (name.Contains("x4"))
        {
            Cutx4();
        }
    }

    #region cut

    public void CutFinish()
    {
        ThumbnailManager.instance.transform.GetChild(ThumbnailManager.instance.vignetteNb).GetChild(0).GetComponent<Image>().sprite = cutFinish;
    }

    public void Cutx2()
    {
        nbCut++;
        ThumbnailManager.instance.transform.GetChild(ThumbnailManager.instance.vignetteNb).GetChild(0).GetComponent<Image>().sprite = cutx2Image[nbCut];
    }

    public void Cutx3()
    {
        nbCut++;
        ThumbnailManager.instance.transform.GetChild(ThumbnailManager.instance.vignetteNb).GetChild(0).GetComponent<Image>().sprite = cutx3Image[nbCut];
    }

    public void Cutx4()
    {
        nbCut++;
        ThumbnailManager.instance.transform.GetChild(ThumbnailManager.instance.vignetteNb).GetChild(0).GetComponent<Image>().sprite = cutx4Image[nbCut];
    }

    public void ResetNbCut()
    {
        nbCut = 0;
    }
    #endregion

    #region knead
    public void KneadFinish()
    {
        ThumbnailManager.instance.transform.GetChild(ThumbnailManager.instance.vignetteNb).GetChild(0).GetComponent<Image>().sprite = kneadFinish;
    }

    public void KneadTwoTouchFinish()
    {
        ThumbnailManager.instance.transform.GetChild(ThumbnailManager.instance.vignetteNb).GetChild(0).GetComponent<Image>().sprite = kneadTwoTouchFinish;
    }
    #endregion

    #region whip
    public void WhipFinish()
    {
        ThumbnailManager.instance.transform.GetChild(ThumbnailManager.instance.vignetteNb).GetChild(0).GetComponent<Image>().sprite = whipFinish;
    }

    public void WhipSwipeDownFinish()
    {
        ThumbnailManager.instance.transform.GetChild(ThumbnailManager.instance.vignetteNb).GetChild(0).GetComponent<Image>().sprite = whipSwipeDownFinish;
    }
    #endregion

    #region cook
    public void CookFinish()
    {
        ThumbnailManager.instance.transform.GetChild(ThumbnailManager.instance.vignetteNb).GetChild(0).GetComponent<Image>().sprite = cookFinish;
    }

    public void CookMaintainFinish()
    {
        ThumbnailManager.instance.transform.GetChild(ThumbnailManager.instance.vignetteNb).GetChild(0).GetComponent<Image>().sprite = cookMaintainFinish;
    }
    #endregion

    #region boil
    public void BoilFinish()
    {
        ThumbnailManager.instance.transform.GetChild(ThumbnailManager.instance.vignetteNb).GetChild(0).GetComponent<Image>().sprite = boilFinish;
    }

    public void BoilSwipeUpFinish()
    {
        ThumbnailManager.instance.transform.GetChild(ThumbnailManager.instance.vignetteNb).GetChild(0).GetComponent<Image>().sprite = boilSwipeUpFinish;
    }
    #endregion
}
