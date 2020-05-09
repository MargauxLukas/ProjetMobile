using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBottom : MonoBehaviour
{
    public float screenHeight;
    public GameObject phase1B;
    public GameObject phase2B;
    public GameObject bottomButtons;
    public GameObject life;

    // Start is called before the first frame update
    void Start()
    {
        screenHeight = Screen.height;
        GetComponent<RectTransform>().offsetMax = new Vector2(GetComponent<RectTransform>().offsetMax.x, -(transform.parent.GetComponent<RectTransform>().rect.height / 2f));

        phase1B.GetComponent<PhaseButtonScale>().ScaleButtons();
        phase2B.GetComponent<PhaseButtonScale>().ScaleButtons();
        bottomButtons.GetComponent<BottomButtonsScale>().ScaleButtons();
        life.GetComponent<LifeScale>().Scale();
    }
}
