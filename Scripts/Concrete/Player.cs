using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer {

    #region PLAYER STATUS
    [SerializeField] private int Health = 0;
    [SerializeField] private int Mana = 0;
    #endregion

    private Animator m_Animator;
    void Start () {
        m_Animator = GetComponent<Animator>();
	}
	

    public void Animate(string animationName, bool isTrigger=false, bool value=true)
    {
        if (isTrigger) m_Animator.SetTrigger(animationName);
        else m_Animator.SetBool(animationName, value);
    }

    public void Attack(IEnemy enemy, int amount, string animation)
    {
        Debug.Log("1. Player Script");
        GameController.AttackToEnemy(enemy);
    }

    public void Die()
    {
        Health = 0;
        Animate("Die", true);
        Destroy(this, 5);
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0)
            Die();
    }

}
