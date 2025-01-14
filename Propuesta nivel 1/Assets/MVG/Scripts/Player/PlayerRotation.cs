using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Camera mainCamera; // Se referencia la main Camera

    void Update()
    {
        RotateTowardsMouse(); // Se llama a la función para rotar el jugador hacia donde esté el mouse
    }

    void RotateTowardsMouse()
    {
        // Se cres un plano en y = 0 (a nivel del suelo)
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        // Se toma la posición del mouse en el espacio de la pantalla de juego
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        // Raycast to the plane
        if (groundPlane.Raycast(ray, out float enter))
        {
            // Get the point on the plane where the ray intersects
            Vector3 hitPoint = ray.GetPoint(enter);

            // Calculate the direction from the player to the hit point
            Vector3 direction = hitPoint - transform.position;

            // Ignore the y-axis to keep the rotation in the X-Z plane
            direction.y = 0;

            // Rotate the player towards the mouse position
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f); // Smooth rotation
            }
        }
    }
}
