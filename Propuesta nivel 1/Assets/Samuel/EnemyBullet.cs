using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]float bulletSpeed;
    [SerializeField]int dmg;

    void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.GetComponent<PlayerHealthController>().ReduceHealth(dmg);
            Destroy(this.gameObject);
        } if(col.gameObject.tag == "Enemy")
        {
            print("te diste soloxd");
        }else {
            Destroy(this.gameObject);
        }
    }
}
