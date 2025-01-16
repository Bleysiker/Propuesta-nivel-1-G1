using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Vida enemigo")]
    public int health;
    public bool isDead = false;

    [Header("Boss")]
    public bool boss;
    public CustomEvents takingDamage;

    int dropNum;
    RandomDrop dropScript;

    [Header("AudioManager del enemigo")]
    public EnemyAudioManager audioManager;

    [Header("Animator")]
    [SerializeField]Animator anim;
    
    void Start()
    {
        dropNum = Random.Range(0,2);
        dropScript = GetComponent<RandomDrop>();
    }

    public void ReduceHealth(int amount)
    {
        if(!isDead)
        {
            health -= amount;
            if (boss) takingDamage.FireEvent();

            if (health < 0) {
                health = 0;
                isDead = true;
                if (!boss) {
                    //Quitando la máscara del apuntado
                    anim.SetLayerWeight(1, 0f);
                    anim.SetBool("isDead", true);

                    //Desactvando el collider
                    CapsuleCollider collider = this.gameObject.GetComponent<CapsuleCollider>();
                    collider.enabled = false;

                    audioManager.PlayDying();
                }
                EnemyDeath();
                Destroy(gameObject, 10f);
            }else {
                if(!boss) audioManager.PlayHit();
            }
        }
            
    }

    void EnemyDeath()
    {
        if (boss) {
            dropNum = 0;
        }
        if(dropNum == 1)
        {
            dropScript.GenerateDrop();
        } else {
            Debug.Log("No tiene drop");
        }
    }
}
