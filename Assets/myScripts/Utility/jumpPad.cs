using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPad : MonoBehaviour
{
    public int upForce = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col) {
        if(col.gameObject.name == "PlayerCharacter"){
            Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up* upForce,ForceMode.Impulse);

        }
    }
}
