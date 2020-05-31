using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyProfile", menuName = "ScriptableObjects/EnemyProfile", order = 1)]
public class EnemyProfile : ScriptableObject
{
    public string Name;
    public int Health;
    public int Mana;
    public int AttackPointMin;
    public int AttackPointMax;
}
