using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public GameObject part;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision col) {

        //Debug.Log("hehe");
        ContactPoint con = col.contacts[0];
        Quaternion rot =  Quaternion.FromToRotation(Vector3.up, con.normal);
        Vector3 pos = con.point;
        Instantiate(part,pos,rot);  

        gameObject.SetActive(false);




    }
}
