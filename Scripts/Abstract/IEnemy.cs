using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy {
    void Attack(int amount, string animationName);
    void Animate(string animation, bool isTrigger, bool value);
    void TakeDamage(int amount);
    void Die();
}
