using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareHealth : MonoBehaviour
{
    public EnemyHealth otherHealth;
    
    public void RedirectDamage(int amount)
    {
        otherHealth.ReduceHealth(amount);
    }
}
