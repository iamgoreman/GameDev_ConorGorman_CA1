using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;
    public float gravity = -10f;
    public float jumpHeight = 5f;
    float verticalForce;
    Vector2 moveDir;
    bool grounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    void Update()

    {
        moveDir = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));

        if(isGrounded() && verticalForce < 0){

            verticalForce = -4f;

        }

        Vector3 move = transform.right * (moveDir.x * speed) + transform.forward * (moveDir.y * speed) + transform.up * verticalForce;
        //Debug.Log(move);
        

        if(Input.GetButtonDown("Jump")) {
            if(isGrounded()){
                verticalForce = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        if(GetComponent<WallRun>().isWallRunning == true){
            Vector3 _wallPath = GetComponent<WallRun>().wallPath.direction;
            Vector3 _oppWall = GetComponent<WallRun>().hit.normal * -1;
            controller.SimpleMove(Vector3.Cross(_wallPath,_oppWall));
            }            

        }
        verticalForce += gravity * Time.deltaTime;
        controller.Move(move * Time.deltaTime);
    }
    public bool isGrounded()
    {
        //we are drawing an invisible line from object to floor.
        //if it hits the floor we are grounded
        //Debug.Log(Physics.Raycast(transform.position, Vector3.down, col.bounds.extents.y + 0.5f));
        return Physics.CheckSphere(groundCheck.position, .4f,groundLayer);
    }

}
