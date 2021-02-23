using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Foe : MonoBehaviour
{
    // Start is called before the first frame update
    public  float enemyHealth = 100f;
    public NavMeshAgent agent;
    public GameObject player;
    public Animator animator;
    public bool dead = false;
    public Rigidbody riggyB;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void takeDamage(float dmgAmount){
        enemyHealth -= dmgAmount;
        Debug.Log(enemyHealth);
        if(enemyHealth<= 0){
            animator.SetTrigger("Dead");
            Invoke(nameof(killEnemy),1.8f);
        }
        else{
            animator.SetTrigger("Hit");
        }
    }
    public virtual void killEnemy(){
        gameObject.SetActive(false);
    }
}
