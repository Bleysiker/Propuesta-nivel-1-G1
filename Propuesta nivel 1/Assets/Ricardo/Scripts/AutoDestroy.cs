
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float lifetime = 5f; // Tiempo en segundos antes de destruir el objeto.

    void Start()
    {
        // Inicia la cuenta atrás para destruir el objeto.
        Invoke(nameof(DestroyObject), lifetime);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
