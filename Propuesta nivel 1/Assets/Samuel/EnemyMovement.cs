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

    //Esta parte solo es para probar el drop. Esto se debe hacer en el script de la vida
    //----------------------------------------------------------------------
    int dropNum;
    RandomDrop dropScript;
    //----------------------------------------------------------------------

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //----------------------------------------------------------------------
        dropNum = 1;
        print(dropNum);
        dropScript = GetComponent<RandomDrop>();
        //----------------------------------------------------------------------

    }

    void Update()
    {
        //----------------------------------------------------------------------
        if(Input.GetKeyDown(KeyCode.Space))
        {
            EnemyDeath();
        }
        //----------------------------------------------------------------------

        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
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

    //Esta parte solo es para probar el drop. Esto se debe hacer en el script de la vida
    //----------------------------------------------------------------------
    void EnemyDeath()
    {
        if(dropNum == 1)
        {
            dropScript.GenerateDrop();
        } else {
            print("No tiene drop");
        }
    }
    //----------------------------------------------------------------------
}
