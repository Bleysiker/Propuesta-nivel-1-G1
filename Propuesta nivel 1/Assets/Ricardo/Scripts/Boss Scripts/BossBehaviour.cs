using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public GameObject objectA;              // Primer objeto hijo.
    public GameObject objectB;              // Segundo objeto hijo.
    public float switchTime = 2f;           // Tiempo que cada objeto permanece activo.
    public float moveDistance = 1f;         // Distancia hacia abajo que se mover� el padre.
    public float moveSpeed = 2f;            // Velocidad de movimiento del padre.
    public bool finalState = false;         // Estado final del boss.

    private bool isObjectAActive = true;    // Indica cu�l objeto est� activo actualmente.
    private Vector3 initialPosition;        // Posici�n original del objeto padre.
    private bool isSwitching = false;       // Para evitar m�ltiples intercambios simult�neos.
    private bool hasFinalStateExecuted = false; // Para asegurarse de que el estado final solo se ejecute una vez.


    [SerializeField] ToggleAnimations bossH1Anim, bossH2Anim;

    void Start()
    {
        bossH1Anim.ChangeAnimationState("Appear");
        bossH2Anim.ChangeAnimationState("Appear");
        // Guarda la posici�n inicial del padre.
        initialPosition = transform.position;

        // Configura el estado inicial de los hijos.
        if (objectA != null && objectB != null) {
            objectA.SetActive(isObjectAActive);
            objectB.SetActive(!isObjectAActive);

            // Inicia el ciclo de intermitencia si no estamos en estado final.
            InvokeRepeating(nameof(StartSwitching), switchTime, switchTime);
        } else {
            Debug.LogError("Faltan referencias a los objetos hijos en el script BossSwitcher.");
        }
    }

    void Update()
    {
        
        
        // Ejecuta el comportamiento final solo una vez cuando `finalState` se activa.
        if (finalState && !hasFinalStateExecuted) {
            hasFinalStateExecuted = true; // Marca que el estado final ya se ejecut�.
            StopAllCoroutines();       // Detiene cualquier corrutina activa.
            CancelInvoke(nameof(StartSwitching)); // Detiene el ciclo de intermitencia.
            StartCoroutine(FinalStateBehavior());
        }
    }

    void StartSwitching()
    {
        // Solo iniciar el intercambio si no est� ya en proceso y no estamos en estado final.
        if (!isSwitching && !finalState) {
            StartCoroutine(SwitchWithMovement());
        }
    }

    IEnumerator SwitchWithMovement()
    {
        
        isSwitching = true;

        // Mueve el objeto padre hacia abajo.
        Vector3 targetPosition = initialPosition - new Vector3(0, moveDistance, 0);
        yield return MoveToPosition(targetPosition);

        // Realiza el intercambio de los objetos hijos.
        isObjectAActive = !isObjectAActive;
        objectA.SetActive(isObjectAActive);
        objectB.SetActive(!isObjectAActive);

        // Mueve el objeto padre de regreso a la posici�n inicial.
        yield return MoveToPosition(initialPosition);

        isSwitching = false;
    }

    IEnumerator FinalStateBehavior()
    {
        isSwitching = true;
        // Mueve el objeto padre hacia abajo por �ltima vez.
        Vector3 targetPosition = initialPosition - new Vector3(0, moveDistance, 0);
        yield return MoveToPosition(targetPosition);

        // Activa ambos objetos permanentemente.
        if (objectA != null) objectA.SetActive(true);
        if (objectB != null) objectB.SetActive(true);

        // Mueve el objeto padre de regreso a la posici�n inicial.
        yield return MoveToPosition(initialPosition);

        Debug.Log("Estado final alcanzado. Ambos objetos est�n activos.");
        isSwitching = false;
    }

    IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        // Mueve el objeto padre suavemente hacia la posici�n objetivo.
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f) {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Aseg�rate de que llegue exactamente a la posici�n objetivo.
        transform.position = targetPosition;
    }
}
