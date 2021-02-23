using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    public float throwSpeed;
    bool thrown;
    public GameObject prefab;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(Camera.main. (new Vector3(Screen.width/2,Screen.height/2,0))));
        if(Input.GetKeyDown(KeyCode.Q)){
            
            GameObject grenade = Instantiate(prefab,spawnPoint.position,transform.rotation);
                Rigidbody riggyb = grenade.GetComponent<Rigidbody>();
                //Debug.Log(riggyb);
                riggyb.AddForce(transform.forward * throwSpeed,ForceMode.Impulse);
        }
    }
}
