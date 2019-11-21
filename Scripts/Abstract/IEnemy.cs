using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy {
    void Attack(IPlayer player, int amount);
    void Animate(ENEMY_ANIMATION animation);
    void TakeDamage(int amount);
    void Die();
}
