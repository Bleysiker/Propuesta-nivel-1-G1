
using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    public float speed = 10f; // Velocidad del proyectil.

    public AudioSource bullet;

    public int damage;
    void Update()
    {
        // Mueve el proyectil hacia adelante.
        transform.position += transform.forward * speed * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            bullet.Play();
            //hace daño al jugador
            other.GetComponent<PlayerHealthController>().ReduceHealth(damage);
            //EFECTO DE DESTRUCCION*****************************
            Destroy(gameObject);
        }
    }
}
