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
    
    void Start()
    {
        dropNum = Random.Range(0,2);
        dropScript = GetComponent<RandomDrop>();
    }

    public void ReduceHealth(int amount)
    {
        health -= amount;
        if (boss) takingDamage.FireEvent();

        if (health < 0) {
            health = 0;
            Debug.Log("Enemy Dead");
            EnemyDeath();
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
