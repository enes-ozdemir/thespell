using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector]
    public Player _player;

    public static Player Player;

    public static SpellProfile CurrentSpell;
    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.FindObjectOfType<Player>();
    }

    public static void AttackToEnemy(IEnemy enemy)
    {
        int power = Mathf.RoundToInt(Random.Range(CurrentSpell.AttackPowerMin, CurrentSpell.AttackPowerMax));
        enemy.TakeDamage(power);
    }

    public static void AttackToPlayer(int amount)
    {
        Player.TakeDamage(amount);
    }

}
