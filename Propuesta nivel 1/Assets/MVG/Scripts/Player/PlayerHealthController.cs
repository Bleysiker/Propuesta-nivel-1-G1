using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class PlayerHealthController : MonoBehaviour
{
    public Image healthBar;
    public int health;
    public bool isShieldActive = false;

    private void Update()
    {
        healthBar.fillAmount = health / 100;
    }

    public void IncreaseHealth(int amount)
    {
        if (health >= 100)
        {
            health = 100;
        }
        else
        {
            health += amount;
            Debug.Log("Health increased: " + health);
        }

        //health = Mathf.Clamp(health, 0, 100);
        //healthBar.fillAmount = health / 100;
    }

    public void ReduceHealth(int amount)
    {
        health -= amount;
        //healthBar.fillAmount = health / 100;
        if (health <= 0) {
            Debug.Log("Player Dead");
        }
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
