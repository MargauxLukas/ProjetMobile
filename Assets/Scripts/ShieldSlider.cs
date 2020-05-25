using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldSlider : MonoBehaviour
{
    public bool isMaintainEat = false;
    public bool eatUp = false;
    public bool eatUpFinal = false;
    private bool isInverse = false;
    private Slider sliderLeft;
    private Slider sliderRight;
    public GameObject sweetSpotRight;
    public GameObject sweetSpotLeft;

    private float min;
    private float max;

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
            if((sliderRight.value >= min && sliderRight.value <= max) || (sliderLeft.value >= min && sliderLeft.value <= max))
            {
                Debug.Log("EatAll");
                FightManager.instance.EatAll();
            }
            else
            {
                Debug.Log("Eat");
                FightManager.instance.Eat();
                ThumbnailManager.instance.Heal();
            }

            eatUp = false;
            sliderRight.value = 0f;
            sliderLeft.value = 0f;
            gameObject.SetActive(false);
        }

        if(eatUpFinal)
        {
            if ((sliderRight.value >= min && sliderRight.value <= max) || (sliderLeft.value >= min && sliderLeft.value <= max))
            {
                LevelManager.instance.topScreen.transform.GetChild(0).GetComponent<FinalLife>().DamageAll();
                ThumbnailManager.instance.HealMax();
            }
            else
            {
                if (sliderRight.value > 0.8f)
                {
                    LevelManager.instance.topScreen.transform.GetChild(0).GetComponent<FinalLife>().Damage(4);
                }
                else if(sliderRight.value > 0.5f)
                {
                    LevelManager.instance.topScreen.transform.GetChild(0).GetComponent<FinalLife>().Damage(3);
                }
                else if (sliderRight.value > 0.25f)
                {
                    LevelManager.instance.topScreen.transform.GetChild(0).GetComponent<FinalLife>().Damage(2);
                }
                else
                {
                    LevelManager.instance.topScreen.transform.GetChild(0).GetComponent<FinalLife>().Damage(1);
                }
                ThumbnailManager.instance.Heal();

                eatUpFinal = false;
                sliderRight.value = 0f;
                sliderLeft.value = 0f;
                gameObject.SetActive(false);
            }
        }
    }

    public void DefineSweetSpot()
    {
        int random = Random.Range(0, 4);

        switch(random)
        {
            case 0:
                min = 0.6f;
                max = 0.7f;
                sweetSpotRight.transform.localPosition = new Vector3(33f, 0f, 0f);
                sweetSpotLeft.transform.localPosition = new Vector3(-(sweetSpotRight.transform.localPosition.x), 0f, 0f);
                break;
            case 1:
                min = 0.7f;
                max = 0.8f;
                sweetSpotRight.transform.localPosition = new Vector3(56f, 0f, 0f);
                sweetSpotLeft.transform.localPosition = new Vector3(-(sweetSpotRight.transform.localPosition.x), 0f, 0f);
                break;
            case 2:
                min = 0.8f;
                max = 0.9f;
                sweetSpotRight.transform.localPosition = new Vector3(79f, 0f, 0f);
                sweetSpotLeft.transform.localPosition = new Vector3(-(sweetSpotRight.transform.localPosition.x), 0f, 0f);
                break;
            case 3:
                min = 0.9f;
                max = 1f;
                sweetSpotRight.transform.localPosition = new Vector3(102f, 0f, 0f);
                sweetSpotLeft.transform.localPosition = new Vector3(-(sweetSpotRight.transform.localPosition.x), 0f, 0f);
                break;

        }
    }
}
