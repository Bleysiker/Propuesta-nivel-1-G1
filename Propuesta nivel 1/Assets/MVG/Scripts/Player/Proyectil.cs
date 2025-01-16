using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float vidaBala = 3; 
    public int dmg = 30; 

    private void Awake()
    {
        Destroy(gameObject, vidaBala);
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            col.GetComponent<EnemyHealth>().ReduceHealth(dmg);
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Boss") {
            col.GetComponent<ShareHealth>().RedirectDamage(dmg);
            Destroy(this.gameObject);
        }
    }
}
