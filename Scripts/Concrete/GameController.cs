using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector]
    public Player _player;

    public static Player Player;
    public static Pet Pet;

    public static SpellProfile CurrentSpell;
    // Start is called before the first frame update
    void Awake()
    {
        Player = FindObjectOfType<Player>();
        Pet = FindObjectOfType<Pet>();
    }

    public static void AttackToEnemy(IEnemy enemy, int amount = 0, string AttackedBy = "")
    {
        Debug.Log("3. GameController");
        int power = 0;
        if (amount == 0)
            power = Mathf.RoundToInt(Random.Range(CurrentSpell.AttackPowerMin, CurrentSpell.AttackPowerMax));
        else
            power = amount;
        enemy.TakeDamage(power);
    }

    public static void AttackToPlayer(int amount)
    {
        Player.TakeDamage(amount);
    }

    public static void AttackToPet(int amount)
    {
        Pet.TakeDamage(amount);
    }

}
