using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuraDrop : MonoBehaviour
{
    public GameObject[] drops;
    float timer = 0;
    float cooldown = 5f;

    [SerializeField] Animator anim;

    public void GenerateDrop()
    {
        int randomNum = Random.Range(0,drops.Length);
        float randomX = Random.Range(-6f,6f);
        float randomZ = Random.Range(4f,5f);
        Vector3 newPos = new Vector3(randomX, 0, randomZ);

        Instantiate(drops[randomNum], transform.position + newPos, Quaternion.identity);

    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    void LateUpdate()
    {
        if(timer >= cooldown)
        {
            timer = 0;
            anim.SetTrigger("Drop");
            //GenerateDrop();
        }
    }

    /* float GenerateRandomNumber()
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
    } */
}
