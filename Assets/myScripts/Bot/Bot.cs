using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot: MonoBehaviour
{

    // Start is called before the first frame update
   public int ID;
   public NavMeshAgent agent;
   public GameObject playerObj;
   public LayerMask player,walkable;
   public float shootTimer,searchTimer,patrolRange,searchRange,attackRange,timeTillAttack;
   Vector3 patrolPoint;
   bool attacking,chasing,patrolling,found,fired;
   Inventory inventory;
   public GameObject projectile, gunSlot;
   Transform playerPos;

   void Start() {
      inventory = GetComponent<Inventory>();
      agent = GetComponent<NavMeshAgent>();
      playerObj = GameObject.FindGameObjectWithTag("Player");
   }

   //USe invoke to call method with a delay
   //find a way to patrol, find random point on map
   //search through list of player/bots to check if they are in line of sight/circle. loop thorugh unit pool to find targets
   //physics.checksphere is great because it uses layer masks
   void Update() {
      playerPos = playerObj.transform;
      found = Physics.CheckSphere(transform.position,patrolRange,player);
      attacking = Physics.CheckSphere(transform.position,attackRange,player);
      if(!found && !attacking){
         Patrolling();
      }

      if(found && !attacking){
         Debug.Log("Chasing");
         Chasing();
      }

      if(found && attacking){
         Attacking();
      }

   }
   void Patrolling(){
      //Debug.Log("searching");
      if(!patrolling){
         Debug.Log("trying to find point");
         NewPatrol();
      }
      if(patrolling){
         agent.SetDestination(patrolPoint);
      }

      //Debug.Log(patrolPoint);
      Debug.DrawLine(transform.position,patrolPoint,Color.red);
      Vector3 dist = transform.position - patrolPoint;
      //Debug.Log("Dist: "+dist.magnitude);
      if(dist.magnitude <4f){
         patrolling = false;
         //Debug.Log("reached");
      }
   }

   void Attacking(){

      //invoke(nameOf(function),float);
      if(!fired){

         GameObject bullet = Instantiate(projectile,gunSlot.transform.position,transform.rotation);
         fired = true;
         Invoke(nameof(ResetTimer),shootTimer);
      }
   }


   void Chasing(){

      agent.SetDestination(playerPos.position);
      //Debug.Log(playerPos.position);
      Debug.DrawLine(transform.position,playerPos.position,Color.red);
      transform.LookAt(playerPos.transform);
   }

   void NewPatrol(){
      float x = Random.Range(-patrolRange,patrolRange);
      float y = Random.Range(-patrolRange,patrolRange);
      float z = Random.Range(-patrolRange,patrolRange);
      //Debug.Log(x);
      patrolPoint = new Vector3(transform.position.x+x,transform.position.y + y,transform.position.z +z);
      //Debug.Log("Generated point");
      if(Physics.Raycast(patrolPoint,-transform.up,2f,walkable)){
         patrolling = true;
         //Debug.Log("patrol true");
      }

   }

   void ResetTimer(){
      Debug.Log("reset fire");
      fired = false;
   }
}
