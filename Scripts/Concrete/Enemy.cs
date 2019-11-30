using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    [SerializeField]
    public string EnemyName { get; private set; }
    [SerializeField]
    public bool IsActive { get; set; }
    [SerializeField]
    public EnemyInfo m_EnemyInfo { get; private set; }
    [SerializeField]
    private Animator m_Animator;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_EnemyInfo = GetComponent<EnemyInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActive)
            CheckPlayer();
    }

    public void Animate(string animation, bool isTrigger=false, bool value=true)
    {
        Debug.Log("6. Animasyon çalıştırıldı ama sanırım aniamsyon yok şuan elimizde :D");
        if (isTrigger) m_Animator.SetTrigger(animation);
        else m_Animator.SetBool(animation,value);
    }

    public void Attack(int amount, string animationName)
    {
        m_Animator.SetBool(animationName, true);
        GameController.AttackToPlayer(amount);
    }

    public void Die()
    {
        Animate("Die", true);
        Destroy(gameObject, 5);
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("5. TakeDamage Düşman hasar aldı hocam" + amount);
        if (m_EnemyInfo.Health - amount > 0)
        {
            m_EnemyInfo.Health -= amount;
            Animate("TakeHit", true);
        }
    }

    private void CheckPlayer()
    {
        //TODO
    }
}
