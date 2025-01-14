
using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    public float speed = 10f; // Velocidad del proyectil.

    void Update()
    {
        // Mueve el proyectil hacia adelante.
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
