using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public static FightManager instance;

    public bool isAttack;
    public bool isDefend;
    public bool isWaiting;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Attack()
    {
        ThumbnailManager.instance.monsterLife.currentLife--;
    }

    public void Defend()
    {
        ThumbnailManager.instance.monsterLife.currentLife--;
    }

    public void Eat()
    {
        ThumbnailManager.instance.monsterLife.currentLife--;
    }
}
