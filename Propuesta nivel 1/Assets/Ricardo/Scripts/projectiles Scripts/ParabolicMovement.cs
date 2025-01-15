using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicMovement : MonoBehaviour
{
    public Transform target;          // El objetivo al que se dirigir� el proyectil.
    public float maxHeight = 10f;    // Altura m�xima de la par�bola.
    public float speed = 5f;         // Velocidad del proyectil.

    private Vector3 startPoint;      // Posici�n inicial del proyectil.
    private Vector3 endPoint;        // Posici�n final del proyectil.
    private float progress;          // Progreso del movimiento (de 0 a 1).

    public GameObject projectileMark;
    private GameObject actualMark;

    public AudioSource bullet;
    public float soundDelay;
    private void Awake()
    {
        target = GameObject.Find("Target").GetComponent<Transform>();
    }

    void Start()
    {
        // Guarda la posici�n inicial del proyectil.
        startPoint = transform.position;

        // Calcula la posici�n final del proyectil (objetivo con offset en Y).
        if (target != null) {
            endPoint = new Vector3(target.position.x, target.position.y, target.position.z);
            actualMark = Instantiate(projectileMark, endPoint, projectileMark.transform.rotation);
        } else {
            Debug.LogWarning("No se ha asignado un objetivo para el proyectil.");
        }
    }

    void Update()
    {
        // Si no hay un objetivo asignado, no hacer nada.
        if (target == null) return;

        // Incrementa el progreso basado en la velocidad y el tiempo.
        progress += speed * Time.deltaTime;

        // Calcula la posici�n en el arco parab�lico.
        Vector3 currentPos = CalculateParabolicPosition(startPoint, endPoint, maxHeight, Mathf.Clamp01(progress));

        // Mueve el proyectil a la posici�n calculada.
        transform.position = currentPos;

        // Si se alcanza el objetivo, destruye el proyectil.
        if (progress >= 1f) {
            OnProjectileHit();
        }
    }

    // Calcula la posici�n del proyectil en el arco parab�lico.
    private Vector3 CalculateParabolicPosition(Vector3 start, Vector3 end, float height, float t)
    {
        // Interpolaci�n lineal entre el punto inicial y final.
        Vector3 linearPos = Vector3.Lerp(start, end, t);

        // Ajuste de la altura parab�lica.
        float parabolaHeight = height * (1 - Mathf.Pow(2 * t - 1, 2)); // F�rmula para el arco parab�lico ajustable.

        return new Vector3(linearPos.x, linearPos.y + parabolaHeight, linearPos.z);
    }

    // L�gica cuando el proyectil llega al destino.
    private void OnProjectileHit()
    {
        Debug.Log("El proyectil ha alcanzado su objetivo.");
        bullet.Play();
        StartCoroutine(DelayDestroy()); // Destruye el proyectil (puedes agregar efectos aqu� si es necesario).
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            bullet.Play();
            //hace da�o al jugador
            //EFECTO DE DESTRUCCION**************************************
            StartCoroutine(DelayDestroy());// Destruye el proyectil (puedes agregar efectos aqu� si es necesario).
        }
    }
    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(soundDelay);
        Destroy(actualMark);
        Destroy(gameObject);
    }
}
