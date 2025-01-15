using System.Collections;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float lifetime = 5f; // Tiempo en segundos antes de destruir el objeto.
    public float soundDelay;
    public AudioSource sound;
    void Start()
    {
        // Inicia la cuenta atrás para destruir el objeto.
        Invoke(nameof(DestroyObject), lifetime);
    }

    void DestroyObject()
    {
        sound.Play();
        StartCoroutine(DestroyBullet());
    }
    
    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(soundDelay);
        Destroy(gameObject);
        //EFECTO DE DESTRUCCION***********************
    }
}
