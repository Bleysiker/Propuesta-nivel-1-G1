using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    // Prefab del proyectil a instanciar.
    public GameObject projectilePrefab;

    // Punto desde el que se disparar� el proyectil.
    public Transform spawnPoint;

    // Intervalo de tiempo entre cada disparo.
    public float spawnInterval = 2f;

    // Control interno del tiempo.
    private float timer;

    public bool active;

    void Update()
    {
        if (active) {
            // Actualiza el temporizador.
            timer += Time.deltaTime;

            // Si el temporizador supera el intervalo, instancia un proyectil.
            if (timer >= spawnInterval) {
                SpawnProjectile();
                timer = 0; // Reinicia el temporizador.
            }
        }
    }

    void SpawnProjectile()
    {
        // Verifica que el prefab y el punto de spawn est�n asignados.
        if (projectilePrefab != null && spawnPoint != null) {
            // Instancia el proyectil en la posici�n y rotaci�n del punto de spawn.
            Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
