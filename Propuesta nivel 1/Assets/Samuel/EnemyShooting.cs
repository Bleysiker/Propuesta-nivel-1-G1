using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform pivot;
    public Transform target;
    public Animator anim;

    public EnemyAudioManager audioManager;

    [SerializeField]float shootRange;

    [SerializeField]EnemyHealth enemyHealth;

    private bool isShooting = false;
    void Awake()
    {
        if(anim == null)
        {
            anim = GetComponent<Animator>();
        }
        
    }

    void Update()
    {
        if(enemyHealth.isDead==false)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, target.position);
            if(distanceToPlayer <= shootRange && !isShooting)
            {
                anim.SetTrigger("shoot");
                isShooting = true;
            }
        }
         
    }
    
    IEnumerator Shooting()
    {
        Instantiate(bullet, pivot.position, pivot.rotation);
        yield return new WaitForSeconds(1f);
        isShooting = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootRange);
    }

    void ShootAnim()
    {
        StartCoroutine(Shooting());
    }

    public void ShootSound()
    {
        audioManager.PlayAttack();
    }

        
    
}
