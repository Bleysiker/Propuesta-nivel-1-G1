using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    
    NavMeshAgent agent;
    [Header("Movimiento del enemigo")]
    [SerializeField]float rangeMax;
    [SerializeField]float rangeMin;
    bool isDetected;
    public Transform target;

    [Header("Animator")]
    [SerializeField] Animator anim;
    
    [Header("Vida del enemigo (EnemyHealth)")]
    [SerializeField]EnemyHealth enemyHealth;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    void Update()
    {
        if(enemyHealth.isDead == false)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, target.position);
            if(distanceToPlayer <= rangeMax)
            {
                isDetected = true;
                anim.SetLayerWeight(1, 1f);
                anim.SetBool("isWalking", true);

                Vector3 directionToPlayer = target.position - transform.position;
                directionToPlayer.y = 0;
                transform.rotation = Quaternion.LookRotation(directionToPlayer);
            }

            if(isDetected && distanceToPlayer > rangeMin)
            {
                anim.SetBool("isWalking", true);
                agent.isStopped = false;
                agent.SetDestination(target.position);

            } else {

                agent.isStopped = true;
                anim.SetBool("isWalking", false);
                
        }
        }
        
    }

   /*  void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangeMax);

        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, rangeMin);
    } */
}
