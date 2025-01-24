using UnityEngine;

public class GameOverSoundTrack : MonoBehaviour
{
    // Instancia única del Singleton
    public static GameOverSoundTrack Instance { get; private set; }

    [SerializeField] private AudioSource soundTrack1, soundTrack2;
    [SerializeField] private AudioSource gameOverSoundTrack;

    private void Awake()
    {
        // Verifica si ya existe una instancia
        if (Instance != null && Instance != this) {
            Destroy(gameObject); // Destruye el duplicado
            return;
        }

        // Asigna esta instancia y marca como persistente si es necesario
        Instance = this;
    }

    public void GameOver()
    {
        soundTrack1.Stop();
        soundTrack2.Stop();
        gameOverSoundTrack.Play();
    }
}

