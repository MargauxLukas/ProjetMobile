using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldSlider : MonoBehaviour
{
    public bool isMaintainEat = false;
    public bool eatUp = false;
    private bool isInverse = false;
    private Slider sliderLeft;
    private Slider sliderRight;

    private void Start()
    {
        sliderRight = transform.GetChild(0).GetComponent<Slider>();
        sliderLeft = transform.GetChild(1).GetComponent<Slider>();
    }

    void Update()
    {
        if(isMaintainEat)
        {
            if (!isInverse)
            {
                sliderRight.value += 0.02f;
                sliderLeft.value += 0.02f;

                if(sliderRight.value >= 1f && sliderLeft.value >= 1f)
                {
                    isInverse = true;
                }
            }
            if (isInverse)
            {
                sliderRight.value -= 0.02f;
                sliderLeft.value -= 0.02f;

                if (sliderRight.value <= 0f && sliderLeft.value <= 0f)
                {
                    isInverse = false;
                }
            }
        }

        if(eatUp)
        {
            if((sliderRight.value >= 0.7f && sliderRight.value <= 0.8f) || (sliderLeft.value >= 0.7f && sliderLeft.value <= 0.8f))
            {
                Debug.Log("EatAll");
                FightManager.instance.EatAll();
            }
            else
            {
                Debug.Log("Eat");
                FightManager.instance.Eat();
            }

            eatUp = false;
            sliderRight.value = 0f;
            sliderLeft.value = 0f;
            gameObject.SetActive(false);
        }
    }
}
