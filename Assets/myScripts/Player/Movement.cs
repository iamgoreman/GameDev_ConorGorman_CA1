using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

   public float speed = 5;
    public float jumpPower = 4;

    Rigidbody rb;
    CapsuleCollider col;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //inputs from the keyboard
        float Horizontal = (Input.GetAxis("Horizontal") * speed) * Time.deltaTime ;
        float Vertical = (Input.GetAxis("Vertical") * speed) * Time.deltaTime ;
        transform.Translate(Horizontal, 0, Vertical);

        if (isGrounded() && Input.GetButton("Jump"))
        {
            //add an upward Force to the rigid body
            Debug.Log("asdfasdf");
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }

        if(Input.GetButton("Jump")){
            Debug.Log("jump around");
        }

        if (Input.GetKeyDown("escape")){
            Cursor.lockState = CursorLockMode.None;
        }
            

    }

    public bool isGrounded()
    {
        //we are drawing an invisible line from object to floor.
        //if it hits the floor we are grounded
        //Debug.Log(Physics.Raycast(transform.position, Vector3.down, col.bounds.extents.y + 0.5f));
        return Physics.Raycast(transform.position, Vector3.down, col.bounds.extents.y + 0.5f);
    }

    //  void Update()
    // {
    //     //inputs from the keyboard
    //     // float Horizontal = (Input.GetAxis("Horizontal") * speed) * Time.deltaTime ;
    //     // float Vertical = (Input.GetAxis("Vertical") * speed) * Time.deltaTime ;
    //     // transform.Translate(Horizontal, 0, Vertical);
    //     movement = new Vector3(Input.GetAxisRaw("Horizontal"),0f,Input.GetAxisRaw("Vertical"));
        
    //     // if (isGrounded() && Input.GetButton("Jump"))
    //     // {
    //     //     //add an upward Force to the rigid body
    //     //     //Debug.Log("asdfasdf");
    //     //     rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    //     // }

    //     if (Input.GetKeyDown("escape")){
    //         Cursor.lockState = CursorLockMode.None;
    //     }
            

    // }
    // void FixedUpdate() {
    //     //moveCharacter(movement);
    //     rb.AddForce((movement * speed));
    // }

    // public bool isGrounded()
    // {
    //     //we are drawing an invisible line from object to floor.
    //     //if it hits the floor we are grounded
    //     //Debug.Log("asdfasdf");
    //     //Debug.Log(Physics.Raycast(transform.position, Vector3.down, col.bounds.extents.y + 0.5f));
    //     return Physics.Raycast(transform.position, Vector3.down, col.bounds.extents.y + 0.5f);
    // }

    // void moveCharacter(Vector3 _direction){
        

    // }
}
