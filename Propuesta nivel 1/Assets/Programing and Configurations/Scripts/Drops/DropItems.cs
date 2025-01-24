using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    public GameObject healthItem;
    public GameObject shieldItem;

    public Transform dropPoint;

    public float dropInterval = 5f;

    void Start()
    {
        // Start the drop loop
        InvokeRepeating("DropRandomItem", dropInterval, dropInterval);
    }

    private void DropRandomItem()
    {
        // Randomly select which item to drop
        GameObject itemToDrop = Random.Range(0, 2) == 0 ? healthItem : shieldItem;

        // Instantiate the item at the NPC's drop point
        Instantiate(itemToDrop, dropPoint.position, Quaternion.identity);
    }

}
