using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGun : MonoBehaviour
{
    bool found;
    BoxCollider boxCollider;
    public string gunName;

    // Start is called before the first frame update
    void Start()
    {
        found = false;
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(found){
            gameObject.SetActive(false);
        }
    }

    public void GetGun(){
        GameObject gun = GameObject.FindWithTag(gunName);
        if(gun.GetComponent<Gun>().found == false){
                gun.GetComponent<Gun>().found = true;
                found = true;
            }
            
    }
    void OnCollisionEnter(Collision col) {
        
    }
}
