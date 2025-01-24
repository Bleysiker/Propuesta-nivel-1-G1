
using UnityEngine;
using System.Collections;
public class LinearMovement : MonoBehaviour
{
    public float speed = 10f; // Velocidad del proyectil.

    public AudioSource bullet;
    public GameObject destroyEffect;
    public float destroyTime;
    GameObject actualGameObject;

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
            actualGameObject=Instantiate(destroyEffect,transform.position,transform.rotation);
            StartCoroutine(DestroyBullet());
        }
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(actualGameObject);
        Destroy(gameObject);
    }
    
}
