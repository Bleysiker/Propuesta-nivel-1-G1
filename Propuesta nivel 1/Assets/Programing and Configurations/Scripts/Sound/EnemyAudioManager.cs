using UnityEngine;

public class EnemyAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource hitSource;
    [SerializeField] private AudioSource attackSource;
    [SerializeField] private AudioSource dyingSource;

    // Método genérico para reproducir cualquier AudioSource
    public void PlaySound(AudioSource source)
    {
        if (source != null && source.clip != null) // Validación para evitar errores
        {
            source.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource o AudioClip no asignado.");
        }
    }

    public void PlayHit()
    {
        hitSource.Play();
    }

    public void PlayAttack()
    {
        attackSource.Play();
    }

    public void PlayDying()
    {
       dyingSource.Play();
    }
}

