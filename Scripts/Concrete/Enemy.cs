using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public string EnemyName { get; private set; }
    public bool IsActive { get; set; }
    public EnemyInfo m_EnemyInfo { get; private set; }
    private Animator m_Animator;
    public bool m_IsAttacking;
    private Player player;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_EnemyInfo = GetComponent<EnemyInfo>();
        player = GameController.Player;
        IsActive = false;
        m_IsAttacking = true;
        StartCoroutine(Test());
    }

    void Update()
    {
        CheckPlayer();

        if (IsActive && GetDistance(transform.position, player.transform.position) > 1)
        {
            m_Animator.SetBool("Walk", true);
            GoToPlayer();
        }
        else
        {
            m_Animator.SetBool("Walk", false);
        }
    }

    private IEnumerator Test()
    {
        while (true)
        {
            if (GetDistance(transform.position, player.transform.position) < 1 && !m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                AttackPlayer();
                yield return new WaitForSeconds(1);
            }
            else
                yield return null;
        }

    }
    private float GetDistance(Vector3 current, Vector3 target)
    {
        return Vector3.Distance(current, target);
    }

    public void Animate(string animation, bool isTrigger = false, bool value = true)
    {
        if (isTrigger) m_Animator.SetTrigger(animation);
        else m_Animator.SetBool(animation, value);
    }

    public void Attack(int amount, string animationName)
    {
        m_Animator.SetBool(animationName, true);
        GameController.AttackToPlayer(amount);
    }

    public void Die()
    {
        Animate("Die", true);
        enabled = false;
        Destroy(gameObject, 5);
    }

    public void TakeDamage(int amount)
    {
        if (m_EnemyInfo.Health - amount > 0)
        {
            m_EnemyInfo.Health -= amount;
            Animate("GetHit", true);
        }
        else
            Die();
    }

    private void CheckPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 10);
        foreach (Collider _collider in colliders)
        {
            if (_collider.CompareTag("Player"))
            {
                IsActive = true;
                break;
            }
        }

    }

    private void GoToPlayer()
    {
        transform.LookAt(player.transform);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.025f);
    }

    private void AttackPlayer()
    {
        m_Animator.SetTrigger("Attack");
        int amount = Random.Range(m_EnemyInfo.AttackPointMin, m_EnemyInfo.AttackPointMax);
        Debug.Log(amount + "Saldırı yedin ");
        GameController.AttackToPlayer(amount);
    }
}