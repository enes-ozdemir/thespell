using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer {

    private PlayerInfo playerInfo;

    private Animator m_Animator;
    void Start () {
        m_Animator = GetComponent<Animator>();
        playerInfo = GetComponent<PlayerInfo>();
	}
	

    public void Animate(string animationName, bool isTrigger=false, bool value=true)
    {
        if (isTrigger) m_Animator.SetTrigger(animationName);
        else m_Animator.SetBool(animationName, value);
    }

    public void Die()
    {
        playerInfo.Health = 0;
        Animate("Die", true);
        Destroy(this, 5);
    }

    public void TakeDamage(int amount)
    {
        playerInfo.Health -= amount;
        if (playerInfo.Health <= 0)
            Die();
    }

    public bool ManaCost(int amount)
    {
        if(playerInfo.Mana - amount >= 0)
        {
            playerInfo.Mana -= amount;
            return true;
        }
        return false;
    }

}
