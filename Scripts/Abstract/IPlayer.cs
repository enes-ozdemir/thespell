public interface IPlayer
{
    void Attack(IEnemy enemy, int amount, string animation);
    void Animate(string animationName, bool isTrigger = false, bool value = true);
    void TakeDamage(int amount);
    void Die();
}