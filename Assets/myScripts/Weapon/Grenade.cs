using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float radius,power;
    public GameObject explosionEffect;
    void Start()
    {
        //this.GetComponent<Rigidbody>().AddForce(transform.forward*speed);

        StartCoroutine("Explosion");
    }

    // Update is called once per frame
    IEnumerator Explosion(){
        yield return new WaitForSeconds(3f);

        Vector3 explosionPos = transform.position;
        Collider[] colls = Physics.OverlapSphere(explosionPos,radius);

        GameObject EFX = Instantiate(explosionEffect,transform.position,Quaternion.identity);

        foreach(Collider hit in colls){
            Rigidbody riggyb = hit.GetComponent<Rigidbody>();

            if(riggyb != null){
                riggyb.AddExplosionForce(power,explosionPos,radius,3f);
            }

        }
        Destroy(gameObject);
        
    }
} 
