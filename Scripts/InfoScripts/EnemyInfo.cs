using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyInfo : MonoBehaviour
{
    public int Health;
    public int Mana;
    public string Name;
    public int AttackPointMin;
    public int AttackPointMax;
    public EnemyProfile EnemyProfile;

    void Awake()
    {
        Health = EnemyProfile.Health;
        Mana = EnemyProfile.Mana;
        Name = EnemyProfile.Name;
        AttackPointMax = EnemyProfile.AttackPointMax;
        AttackPointMin = EnemyProfile.AttackPointMin;
    }
}
