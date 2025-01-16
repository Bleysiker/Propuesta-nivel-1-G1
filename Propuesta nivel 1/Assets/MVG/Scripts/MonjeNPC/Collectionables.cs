using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectionables : MonoBehaviour
{
    public enum ItemType { Health, Shield }
    public ItemType itemType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealthController player = other.GetComponent<PlayerHealthController>();

            if (player != null)
            {
                // Apply effects based on the item type
                switch (itemType)
                {
                    case ItemType.Health:
                        player.IncreaseHealth(20); // Add health
                        break;
                    case ItemType.Shield:
                        player.ActivateShield(5f); // Activate shield for 5 seconds
                        break;
                }
            }

            // Destroy the item after it's collected
            Destroy(gameObject);
        }
    }
}
