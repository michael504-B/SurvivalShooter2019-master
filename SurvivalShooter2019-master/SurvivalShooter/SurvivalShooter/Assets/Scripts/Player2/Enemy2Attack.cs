using UnityEngine;
using System.Collections;

public class Enemy2Attack : MonoBehaviour
{

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


    Animator anim;
    GameObject player2;
    Player2Health player2Health;
    EnemyHealth enemyHealth;
    bool player2InRange;
    float timer;


    void Awake()
    {
        player2 = GameObject.FindGameObjectWithTag("Player2");
        player2Health = player2.GetComponent<Player2Health>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player2)
        {
            player2InRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player2)
        {
            player2InRange = false;
        }
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && player2InRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }

        if (player2Health.current2Health <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }


    void Attack()
    {
        timer = 0f;

        if (player2Health.current2Health > 0)
        {
            player2Health.TakeDamage (attackDamage);
        }
    }
}
