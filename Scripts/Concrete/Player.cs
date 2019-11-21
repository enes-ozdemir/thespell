using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer {

    #region PLAYER STATUS
    [SerializeField] private int Health = 0;
    [SerializeField] private int Mana = 0;
    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleInput();
	}

    public void Animate(PLAYER_ANIMATION animation)
    {
        
    }

    public void Attack(IEnemy enemy, int amount)
    {
        enemy.TakeDamage(amount);
    }

    public void Die()
    {
        Health = 0;
        Animate(PLAYER_ANIMATION.DIE);
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0)
            Die();
    }

    private void HandleInput()
    {

    }
}
