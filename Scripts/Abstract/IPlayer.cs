public interface IPlayer
{
    void Attack(IEnemy enemy, int amount);
    void Animate(PLAYER_ANIMATION animation);
    void TakeDamage(int amount);
    void Die();
}