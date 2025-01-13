using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public bool boss;
    public CustomEvents takingDamage;
    
    public void ReduceHealth(int amount)
    {
        health -= amount;
        if (boss) takingDamage.FireEvent();

        if (health < 0) {
            health = 0;
            Debug.Log("Dead");
        }
    }
}
