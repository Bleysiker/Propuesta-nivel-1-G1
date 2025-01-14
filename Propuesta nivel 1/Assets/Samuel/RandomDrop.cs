using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDrop : MonoBehaviour
{
    public GameObject[] drops;

    public void GenerateDrop()
    {
        int randomNum = Random.Range(0,drops.Length);
        float randomX = GenerateRandomNumber();
        float randomZ = GenerateRandomNumber();
        Vector3 newPos = new Vector3(randomX, 0, randomZ);

        Instantiate(drops[randomNum], transform.position + newPos, Quaternion.identity);

    }

    float GenerateRandomNumber()
    {
        float random = Random.value;
        if (random < 0.5f)
        {
            return Random.Range(-2.5f, -1f);
        }
        else
        {
            return Random.Range(1f, 2.5f);
        }
    }
}
