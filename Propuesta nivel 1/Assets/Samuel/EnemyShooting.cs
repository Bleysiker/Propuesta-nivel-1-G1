using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform pivot;
    public Transform target;

    [SerializeField]float shootRange;

    private bool isShooting = false;

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if(distanceToPlayer <= shootRange && !isShooting)
        {
            StartCoroutine(Shooting());
        } 
    }
    IEnumerator Shooting()
    {
        isShooting = true;
        Instantiate(bullet, pivot.position, pivot.rotation);
        yield return new WaitForSeconds(5f);
        isShooting = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootRange);
    }

        
    
}
