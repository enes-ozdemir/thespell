public interface IPlayer
{
    void Animate(string animationName, bool isTrigger = false, bool value = true);
    void TakeDamage(int amount);
    void Die();
}