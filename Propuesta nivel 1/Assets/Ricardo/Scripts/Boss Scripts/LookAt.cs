using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    // Referencia al objeto que queremos mirar.
    public Transform target;

    

    void Update()
    {
        // Aseg�rate de que hay un objeto objetivo asignado.
        if (target != null) {
            // Calcula la direcci�n hacia el objetivo.
            Vector3 direction = target.position - transform.position;
            direction.y = 0;
            // Calcula la rotaci�n deseada hacia el objetivo.
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            // Suaviza la rotaci�n para hacerla m�s natural.
            transform.rotation = targetRotation;
        }
    }
}
