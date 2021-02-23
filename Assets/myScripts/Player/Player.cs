using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
   
    public int health; 
    bool dead;
    public Camera deathCam, mainCam;
    float deathTimer = 3f;
    CharacterController cc;
    public Inventory inventory;
    void Start() {
        cc = GetComponent<CharacterController>();
        inventory = gameObject.GetComponentInChildren<Inventory>();
    }

    void Update() {
          

          if(health <= 0 && !dead){
              KillPlayer();
          }
            // make guns have one renderer
          if(Input.GetButtonDown("Fire1")){
              if(!PauseMenu.isPaused){
                  for (int i = 0; i < inventory.bag.Length; i++)
                    {
                       
                        if(inventory.bag[i].GetComponent<Weapon>()!=null && inventory.bag[i].GetComponent<Weapon>().held){
                            
                            inventory.bag[i].GetComponent<Weapon>().Fire();
                        }
                    
                    }
              }
              
          }
    }

    

    void KillPlayer(){
        dead = true;
        gameObject.GetComponent<CharacterController>().enabled = false;
    }

    void RespawnPlayer(){
        health = 100;;
        gameObject.GetComponent<CharacterController>().enabled = true;
        dead = false;
    }

    void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit != null){
            if(hit.gameObject.tag == "Magazine"){    
                Debug.Log("tag");
                GameObject gun = GameObject.FindGameObjectWithTag("Handgun");
                if(gun != null){
                    if(gun.GetComponent<Gun>().CheckAmmo()){
                    hit.gameObject.GetComponent<AmmoPickUp>().Deactivate();
                }
                    else{
                        Physics.IgnoreCollision(hit.collider,cc);
                    }
                }
                
                    
            }
        if(hit.gameObject.tag == "PickUpGun"){
            
            PickUpGun pickUp = hit.gameObject.GetComponent<PickUpGun>();
            if(pickUp != null){
                pickUp.GetGun();
            }
            else{
                Physics.IgnoreCollision(cc,hit.collider);
            }
        }

            if(hit.gameObject.tag == "ShotgunPack"){
                GameObject gun = GameObject.FindGameObjectWithTag("Shotgun");
                if(gun.GetComponent<Gun>().CheckAmmo()){
                    hit.gameObject.GetComponent<AmmoPickUp>().Deactivate();
                }
                else{
                    Physics.IgnoreCollision(hit.collider,cc);
                }
            }
            
            
        }
    }
}