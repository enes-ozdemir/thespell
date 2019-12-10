using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour, IPet
{
    [SerializeField]
    public int Health { get; private set; }
    public int PetMaxAttack { get; private set; }
    public int PetMinAttack { get; private set; }
    public PetStatus PetStatus { get; set; }

    private Animator m_Animator;
    private bool CanMove = true;
    private Rigidbody m_Rigidbody;
    void Start()
    {
        m_Animator = GetComponent<Animator>();

        PetMaxAttack = 5;
        PetMinAttack = 1;
        Health = 100;
        PetStatus = PetStatus.IDLE;
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator.SetBool("Walk", true);

    }

    void Update()
    {
        if (PetStatus == PetStatus.FOLLOWING && Check360Degree() && CanMove)
        {
            GotoTarget(CalculateSafeWay());
        }
       

    }

    public void Attack(IEnemy enemy)
    {
        int power = Mathf.RoundToInt(Random.Range(PetMinAttack, PetMaxAttack));
        GameController.AttackToEnemy(enemy, power, "pet");
    }

    public Vector3 CalculateSafeWay()
    {
        throw new System.NotImplementedException();
    }

    public bool Check360Degree()
    {
        throw new System.NotImplementedException();
    }

    public void Defense()
    {
        PetStatus = PetStatus.DEFENSING;
    }

    public void Die()
    {
        m_Animator.SetTrigger("Death");
        PetStatus = PetStatus.DEAD;
        Destroy(gameObject, 5);
    }

    public void Follow()
    {
        CanMove = true;
        m_Animator.SetBool("Walk", true);
    }

    public void GotoTarget(Vector3 position)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            CanMove = false;
            Die();
        }
        else
        {
            m_Animator.SetTrigger("GetHit");
        }
    }

    public void Wait()
    {
        m_Animator.SetBool("Walk", false);
        CanMove = false;
    }
}

public enum PetStatus
{
    FOLLOWING,
    IDLE,
    ATTACKING,
    DEFENSING,
    DEAD
}
