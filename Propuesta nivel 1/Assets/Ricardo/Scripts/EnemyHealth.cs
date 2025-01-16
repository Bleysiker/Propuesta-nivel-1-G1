using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public bool boss;
    public CustomEvents takingDamage;

    int dropNum;
    RandomDrop dropScript;

    public EnemyAudioManager audioManager;

    public bool isDead = false;
    
    void Start()
    {
        //dropNum = Random.Range(0,2);
        dropNum = 1;
        dropScript = GetComponent<RandomDrop>();
    }

    public void ReduceHealth(int amount)
    {
        if(!isDead)
        {
            health -= amount;
            if (boss) takingDamage.FireEvent();

            if (health < 0) {
                health = 0;
                isDead = true;
                Debug.Log("Enemy Dead");

                //Desactvando el collider
                SphereCollider collider = this.gameObject.GetComponent<SphereCollider>();
                if (collider != null)
                {
                    collider.enabled = false;
                }
                
                audioManager.PlayDying();
                EnemyDeath();
            }
        }
            
    }

    void EnemyDeath()
    {
        if(dropNum == 1)
        {
            dropScript.GenerateDrop();
        } else {
            Debug.Log("No tiene drop");
        }
    }
}
