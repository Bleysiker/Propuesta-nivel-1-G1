using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f; // Velocidad de movimiento del Jugador

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool movePressed = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") !=0 ;

        float moveHorizontal = Input.GetAxis("Horizontal"); // Mover el jugador de forma horizontal con teclas lados o A y D
        float moveVertical = Input.GetAxis("Vertical"); // Mover el jugador de forma Vetical con teclas arriba y abajo o W y S

        if (!isWalking && movePressed)
        {
            animator.SetBool("isWalking", true);
        }

        if (isWalking && !movePressed)
        {
            animator.SetBool("isWalking", false);
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized; // Vector normalizado
        transform.position += movement * speed * Time.deltaTime; // Movimiento independiente de la rotación

    }
}
