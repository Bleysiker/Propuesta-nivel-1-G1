using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform posicionSpawneo;
    public float balaVelocidad;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //&& puedeDisparar)
        {
            var bala = Instantiate(balaPrefab, posicionSpawneo.position, posicionSpawneo.rotation);
            bala.GetComponent<Rigidbody>().velocity = posicionSpawneo.forward * (balaVelocidad);
            
        }
    }
}
