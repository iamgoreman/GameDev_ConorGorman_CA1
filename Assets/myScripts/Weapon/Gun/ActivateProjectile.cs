using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateProjectile : MonoBehaviour
{
    public float timeTillDeath;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            
            GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f,0f,speed),ForceMode.VelocityChange);
            Destroy(this.gameObject,timeTillDeath);
            
        
    }
}
