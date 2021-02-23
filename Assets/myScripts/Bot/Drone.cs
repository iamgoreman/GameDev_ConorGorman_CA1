using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Drone : Foe
{
    public float minJumpRange, minAttackRange;
    public float maxJumpRange, maxAttackRange;
    public int damage;
    public float jumpValue;
    public Transform groundCheck,jumpBlock;
    public LayerMask groundLayer,playerLayer;
    bool jump ,apex, attack;
    BoxCollider boxCollider;
    CapsuleCollider capsuleCollider;
    float jumpTime = 2f,jumpClock=0f;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Chasing",true);
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");  
        animator = GetComponent<Animator>(); 
        riggyB = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        jump = false;
        apex = false;
        attack = false;
        playerLayer = LayerMask.GetMask("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(jump && isGrounded()){
            jumpClock += Time.deltaTime;
        }

        if(jumpClock > jumpTime){
            jump = false;
            jumpClock = 0f;
        }
        RaycastHit heightCheck;
        if(agent.enabled){
            agent.SetDestination(player.transform.position);
        }
  
        float distance = Vector3.Distance(transform.position,player.transform.position);
        

        if(distance < maxAttackRange &&  distance > minAttackRange && !attack){
            Attack();
            //agent.enabled = true;
        }
        if(distance <= maxJumpRange &&  distance >= minJumpRange && !jump){
            if(CheckLineofSight()){
                Leap();
            }
          
        }
        if(Physics.Raycast(groundCheck.position, Vector3.down, out heightCheck, 2f, groundLayer) && jump){
          
            if(heightCheck.distance > .6f){
                apex = true;
            }
        }

        if(isGrounded() && apex){
            Landed();  
        }
    }

    public bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f,groundLayer);
    }

    public void Leap(){
        animator.SetTrigger("Leaping");
        agent.enabled = false;
        riggyB.AddRelativeForce( ((Vector3.forward*2.5f + Vector3.up*3.2f)*jumpValue), ForceMode.Impulse);Debug.Log("leaping");
        jump = true;
    }

    public void Landed(){
        agent.enabled = true;
        apex = false;
    }

    public void TimerReset(){
        jumpClock = 0;
        jump = false;
    }

    public void Attack(){
        animator.SetTrigger("Attacking");
    }

    public bool CheckLineofSight(){
        RaycastHit hit;
        bool result = false;
        if(Physics.Raycast(jumpBlock.position,transform.forward * 8 + new Vector3(.2f,+1f,0),out hit,maxJumpRange,playerLayer)){

            result = true;
        }
        else{
            result = false;

        }
        return result;
    }

    public void TriggerBox(){
        boxCollider.enabled = !boxCollider.enabled;
    }

    public void DamagePlayer(int _damageValue){
        player.GetComponent<PlayerDamage>().ApplyDamage(damage);
        //player.GetComponent<CharacterController>().Move(Vector3.back);
    }
 
    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "Magazine" || col.gameObject.tag == "ShotgunPack"){
            Physics.IgnoreCollision(capsuleCollider,col.collider);
        }
        if(col.collider.GetType() == typeof(CharacterController)){
            if(jump && !apex){
            DamagePlayer(damage);
            riggyB.AddRelativeForce(Vector3.down,ForceMode.Impulse);
            }
            
            
        }

        if(col.gameObject.tag == "Building"){
            //Debug.Log("building collision");
            if(Physics.Raycast(jumpBlock.position,transform.forward,.6f)){
                //Debug.Log("building ray");
                if(jump && !apex){
                    
                //riggyB.AddRelativeForce(Vector3.down,ForceMode.Impulse);
                }
            }
            
        }

        if(col.gameObject.tag == "Foe"){
            Physics.IgnoreCollision(capsuleCollider,col.collider);
        }
        
        
    }
}
