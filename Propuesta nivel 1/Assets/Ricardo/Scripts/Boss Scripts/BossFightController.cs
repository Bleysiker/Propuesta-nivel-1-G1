using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossFightController : MonoBehaviour
{
    public GameObject boss;   // Referencia al objeto que se va a mover.
   

    public float delayStart, delayEnd;

    public EnemyHealth bossHealth;
    public ProjectileSpawner[] spawn;
    public BossBehaviour bossBehaviour;
    public CustomEvents takingDamage;

    public Slider healthBar;
    public bool alreadyFigthing=false;
    void Start()
    {
        healthBar.maxValue = bossHealth.health;
        healthBar.value = healthBar.maxValue;
        takingDamage.GEvent += BossStatus;
        healthBar.gameObject.SetActive(false);
    }
    
    // activar o desactivar los spawners de proyectiles
    void SwitchAttack(bool state)
    {
        foreach(ProjectileSpawner spawner in spawn) {
            spawner.active = state;
        }
    }

    //-----------------------Empezar el boss fight


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            if(!alreadyFigthing)
            BeginFight();
        }
    }

    //----------------Verificar como va la salud del jefe

    void BossStatus()
    {
        healthBar.value = bossHealth.health;
        if (healthBar.value <= (healthBar.maxValue / 2)) {
            bossBehaviour.finalState = true;
        }

        if (bossHealth.health <= 0) {
            EndFight();
        }
    }


    //------------------------------------- funciones para la posicion y estado del boss fight

    public void BeginFight()
    {
        alreadyFigthing = true;
        SwitchAttack(true);
        // Inicia la corrutina para mover el objeto hacia la posición objetivo.
        if (boss != null) {
            StartCoroutine(MoveObject(boss,delayStart,true));
        }
    }

    public void EndFight()
    {
        SwitchAttack(false);
        // Inicia la corrutina para regresar el objeto a su posición inicial.
        if (boss != null) {
            StartCoroutine(MoveObject(boss,delayEnd,false));
        }
    }

    IEnumerator MoveObject(GameObject obj, float delay,bool status)
    {
        yield return new WaitForSeconds(delay);
        // Mueve el objeto suavemente hacia la posición de destino.
        obj.SetActive(status);
        healthBar.gameObject.SetActive(status);
    }

    private void OnEnable()
    {
        takingDamage.GEvent -= BossStatus;
    }
    private void OnDestroy()
    {
        takingDamage.GEvent -= BossStatus;
    }

}
