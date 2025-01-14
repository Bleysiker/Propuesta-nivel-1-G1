using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f; // Velocidad de movimiento del Jugador

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Mover el jugador de forma horizontal con teclas lados o A y D
        float moveVertical = Input.GetAxis("Vertical"); // Mover el jugador de forma Vetical con teclas arriba y abajo o W y S

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // Nuevo vector movement para aplicar el movimiento al Jugador
        transform.Translate(movement * speed * Time.deltaTime); // Se le aplica el movimiento al jugador en la dirección de las teclas y con la velocidad establecida

    }
}
