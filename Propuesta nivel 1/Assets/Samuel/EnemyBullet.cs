using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]float bulletSpeed;

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
            //Quitar vida
            print("Le diste we");
            Destroy(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
    }
}
