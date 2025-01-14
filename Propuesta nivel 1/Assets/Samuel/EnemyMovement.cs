using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    //[SerializeField]private float speed;
    [SerializeField]float rangeMax;
    [SerializeField]float rangeMin;

    public Animator anim;

    public Transform target;

    bool isDetected;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(anim == null)
        {
            print("No encuentro el animator mi hermano");
        }
        agent.updateRotation = false;

        

        

    }

    void Update()
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

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangeMax);

        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, rangeMin);
    }
}
