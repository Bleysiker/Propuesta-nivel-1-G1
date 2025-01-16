using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    // Prefab del proyectil a instanciar.
    public GameObject projectilePrefab;

    // Punto desde el que se disparará el proyectil.
    public Transform spawnPoint;

    // Intervalo de tiempo entre cada disparo.
    public float spawnInterval = 2f;

    // Control interno del tiempo.
    private float timer;
    [SerializeField] float delay;
    private bool initialDelay;
    public bool active;

    public SoundStorage storage;
    public int soundAppear,soundHAtk,soundPS;

    void Update()
    {
        if (active) {
            // Actualiza el temporizador.
            timer += Time.deltaTime;
            if(!initialDelay) {
                if (timer >= delay) {
                    initialDelay = true;
                    timer = 0;
                }
            } else {
                // Si el temporizador supera el intervalo, instancia un proyectil.
                if (timer >= spawnInterval) {
                    SpawnProjectile();
                    timer = 0; // Reinicia el temporizador.
                }
            }
        }
    }

    void SpawnProjectile()
    {
        //EFECTO DE DISPARO*************
        storage.audio[soundHAtk].Play();
        storage.audio[soundPS].Play();
        // Verifica que el prefab y el punto de spawn estén asignados.
        if (projectilePrefab != null && spawnPoint != null) {
            // Instancia el proyectil en la posición y rotación del punto de spawn.
            Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
    private void OnDisable()
    {
        initialDelay = false;
        timer = 0;
    }
    private void OnEnable()
    {
        storage.audio[soundAppear].Play();
        //EFECTO DE SPLASHHH************
    }
}
