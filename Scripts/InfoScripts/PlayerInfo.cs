using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int Health;
    public int Mana;
    public string Name;
    public PlayerProfile PlayerProfile;

    void Awake()
    {
        Health = PlayerProfile.Health;
        Mana = PlayerProfile.Mana;
        Name = PlayerProfile.Name;
    }
}
