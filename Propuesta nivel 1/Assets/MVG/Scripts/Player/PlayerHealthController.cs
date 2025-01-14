using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int health;
    
    public void ReduceHealth(int amount)
    {
        health -= amount;
        if (health <= 0) {
            Debug.Log("Dead");
        }
        
    }
}
