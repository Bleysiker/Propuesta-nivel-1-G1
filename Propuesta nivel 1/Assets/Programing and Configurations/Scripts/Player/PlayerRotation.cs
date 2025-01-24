using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Camera mainCamera; // Se referencia la cámara principal

    void Update()
    {
        RotateTowardsMouse(); // Llama a la función para rotar el jugador hacia donde esté el mouse
    }

    void RotateTowardsMouse()
    {
        // Crea un plano dinámico a la altura del jugador
        Plane groundPlane = new Plane(Vector3.up, new Vector3(0, transform.position.y, 0));

        // Obtiene la posición del mouse en el espacio de la pantalla de juego
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        // Lanza un rayo hacia el plano
        if (groundPlane.Raycast(ray, out float enter))
        {
            // Obtiene el punto en el plano donde el rayo intersecta
            Vector3 hitPoint = ray.GetPoint(enter);

            // Calcula la dirección desde el jugador hacia el punto de impacto
            Vector3 direction = hitPoint - transform.position;

            // Ignora el eje Y para mantener la rotación en el plano X-Z
            direction.y = 0;

            // Rota al jugador hacia la posición del mouse
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f); // Rotación suave
            }
        }
    }
}
