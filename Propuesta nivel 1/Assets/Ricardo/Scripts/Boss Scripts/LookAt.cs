using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    // Referencia al objeto que queremos mirar.
    public Transform target;

    

    void Update()
    {
        // Asegúrate de que hay un objeto objetivo asignado.
        if (target != null) {
            // Calcula la dirección hacia el objetivo.
            Vector3 direction = target.position - transform.position;
            direction.y = 0;
            // Calcula la rotación deseada hacia el objetivo.
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            // Suaviza la rotación para hacerla más natural.
            transform.rotation = targetRotation;
        }
    }
}
