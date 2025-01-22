using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossFightController : MonoBehaviour
{
    public GameObject boss,fullStage;   // Referencia al objeto que se va a mover.
   

    public float delayStart, delayEnd;

    public EnemyHealth bossHealth;
    public ProjectileSpawner[] spawn;
    public BossBehaviour bossBehaviour;
    public CustomEvents takingDamage;

    public Slider healthBar;
    public bool alreadyFigthing=false;

    [SerializeField] ToggleAnimations bossH1Anim, bossH2Anim;


    [SerializeField] SoundStorage storage;

    public GameObject deadEffect;
    public Transform[] headPosition;
    //public GameObject[] innactiveEffect;

    public GameObject priest;  

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
        SmoothSoundtrackTransition.Instance.TransitionToSecondTrack();
        priest.SetActive(true);
        alreadyFigthing = true;
        SwitchAttack(true);
        // Inicia la corrutina para mover el objeto hacia la posici�n objetivo.
        if (boss != null) {
            StartCoroutine(MoveObject(fullStage,delayStart,true));
        }
    }

    public void EndFight()
    {
        //EFECTO DE MUERTE O EXPLOSION DE VICERAS*********************
        bossH1Anim.ChangeAnimationState("Dead");
        bossH2Anim.ChangeAnimationState("Dead");

        foreach(Transform pos in headPosition) {
            Instantiate(deadEffect, pos.position, pos.rotation);
        }
        //foreach(GameObject effect in innactiveEffect) {
        //    effect.SetActive(false);
        //}

        storage.audio[2].Play();
        storage.audio[3].Play();

        SwitchAttack(false);
        // Inicia la corrutina para regresar el objeto a su posici�n inicial.
        if (boss != null) {
           StartCoroutine(MoveObject(boss,delayEnd,false));
        }
    }

    IEnumerator MoveObject(GameObject obj, float delay,bool status)
    {
        yield return new WaitForSeconds(delay);
        // Mueve el objeto suavemente hacia la posici�n de destino.
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
