using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothSoundtrackTransition : MonoBehaviour
{
    public static SmoothSoundtrackTransition Instance { get; private set; } // Singleton instance

    public AudioSource audioSource1; // Primer AudioSource
    public AudioSource audioSource2; // Segundo AudioSource
    public float transitionDuration = 2.0f; // Duración de la transición en segundos
    private float actualVolume;


    private void Awake()
    {
        // Configuración del Singleton
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject); // Evita duplicados
        }
    }

    private void Start()
    {
        actualVolume = audioSource1.volume;
        // Asegúrate de que ambos AudioSources estén configurados correctamente
        if (audioSource1 != null && audioSource2 != null) {
            audioSource1.Play(); // Reproduce el primer audio al iniciar
        }
    }

    public void TransitionToSecondTrack()
    {
        if (audioSource1.isPlaying) {
            StartCoroutine(TransitionAudio(audioSource1, audioSource2));
        }
    }

    public void TransitionToFirstTrack()
    {
        if (audioSource2.isPlaying) {
            StartCoroutine(TransitionAudio(audioSource2, audioSource1));
        }
    }

    private IEnumerator TransitionAudio(AudioSource from, AudioSource to)
    {
        float timer = 0f;

        to.Play(); // Comienza a reproducir el segundo audio

        while (timer < transitionDuration) {
            timer += Time.deltaTime;
            float t = timer / transitionDuration;

            // Reducir el volumen del primer audio y aumentar el del segundo
            from.volume = Mathf.Lerp(actualVolume, 0f, t);
            to.volume = Mathf.Lerp(0f, actualVolume, t);

            yield return null; // Esperar al siguiente frame
        }

        from.Stop(); // Detiene el primer audio una vez finalizada la transición
    }
}
