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
    public Transform target;

    bool isDetected;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        //print(distanceToPlayer);

        if(distanceToPlayer <= rangeMax)
        {
            isDetected = true;
        }

        if(isDetected && distanceToPlayer > rangeMin)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);

        } else {

            agent.isStopped = true;
            
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
