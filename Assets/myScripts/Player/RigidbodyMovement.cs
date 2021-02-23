using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    
    public float moveSpeed;
    Rigidbody riggyb;
    Vector3 moveDir;
    // Start is called before the first frame update
    void Awake() {
     riggyb = GetComponent<Rigidbody>();       
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = (Input.GetAxis("Horizontal")*transform.right + Input.GetAxis("Vertical")* transform.forward).normalized;
    }

    void FixedUpdate() {
        Move();
    }

    void Move(){
        //riggyb.velocity = (moveDir * (moveSpeed*100) * Time.deltaTime);
        //riggyb.AddForce(moveDir*moveSpeed);
        //riggyb.MovePosition( transform.position + (moveDir * moveSpeed * Time.deltaTime)) ;
    }
}
