using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float vidaBala = 3; 

    private void Awake()
    {
        Destroy(gameObject, vidaBala);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Restar vida a enemigos

        //Destroy(collision.gameObject);
        //Destroy(gameObject);
    }
}
