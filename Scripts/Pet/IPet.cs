using UnityEngine;
public interface IPet
{
    void GotoTarget(Vector3 position);
    void Attack(IEnemy enemy);
    void Follow();
    void TakeDamage(int amount);
    void Defense();
    void Wait();
    void Die();
    bool Check360Degree();
    Vector3 CalculateSafeWay();
}