using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    bool active = true;
    public float respawnTimer;
    void Update()
    {   
        if(!active){
            Invoke(nameof(Reactivate),respawnTimer);
            active = true;
        }
    }

    public void Deactivate(){
        gameObject.GetComponent<BoxCollider>().enabled = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            
            transform.GetComponentInChildren<MeshRenderer>().enabled =false;
        }
        active = false;
    }

    public void Reactivate(){
        gameObject.GetComponent<BoxCollider>().enabled = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetComponentInChildren<MeshRenderer>().enabled =true;
        }

    }
    // void Respawn(){
    //     Debug.Log("activating");
    //     active = true;
    //     gameObject.SetActive(active);
    // }
}
