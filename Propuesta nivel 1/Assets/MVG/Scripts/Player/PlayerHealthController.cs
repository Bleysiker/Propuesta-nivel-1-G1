using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{
    public int health;
    public bool isShieldActive = false;
    public GameObject shieldPrefab;


    private void Update()
    {
        // Activa o desactiva el escudo según el estado de isShieldActive
        if (shieldPrefab != null)
        {
            shieldPrefab.SetActive(isShieldActive);
        }
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

    }

    public void ReduceHealth(int amount)
    {
        if (isShieldActive)
        {
            Debug.Log("Shield is active! No damage taken.");
            return; // No se aplica daño si el escudo está activo
        }

        health -= amount;
        Debug.Log("Health reduced: " + health);

        if (health <= 0)
        {
            Debug.Log("Player Dead");
            Time.timeScale = 0;
            SceneManager.LoadScene("GameOver");
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
