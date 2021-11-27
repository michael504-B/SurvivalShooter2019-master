using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    Transform player2;
    PlayerHealth playerHealth;
    PlayerHealth playerHealth2;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        player2 = GameObject.FindGameObjectWithTag("Player2").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        playerHealth2 = player2.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


    void Update ()
    {
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 || enemyHealth.currentHealth > 0 && playerHealth2.currentHealth > 0)
        {
            nav.SetDestination (player.position);
            
        }
        
        else
        {
            nav.enabled = false;
        }
    }
}
