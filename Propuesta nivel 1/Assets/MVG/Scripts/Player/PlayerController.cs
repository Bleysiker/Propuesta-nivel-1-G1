using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health = 100;
    public bool isShieldActive = false;

    public void IncreaseHealth(int amount)
    {
        health += amount;
        Debug.Log("Health increased: " + health);
    }

    public void ActivateShield(float duration)
    {
        if (isShieldActive) return;

        isShieldActive = true;
        Debug.Log("Shield activated!");
        // Start a coroutine to disable the shield after the duration
        StartCoroutine(DeactivateShieldAfterTime(duration));
    }

    private System.Collections.IEnumerator DeactivateShieldAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        isShieldActive = false;
        Debug.Log("Shield deactivated!");
    }
}
