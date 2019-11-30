using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProfile", menuName = "ScriptableObjects/PlayerProfile", order = 2)]
public class PlayerProfile : ScriptableObject
{
    public string Name;
    public int Health = 100;
    public int Mana = 100;
}
