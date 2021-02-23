using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRun : MonoBehaviour
{
    public CharacterController playerCC;
    public LayerMask runnable;
    public float speed = 10;
    public float wallDist;
    bool OnWall,foundWall;
    int wallPathDir;
    public bool isWallRunning;
    public RaycastHit hit;
    Vector3[] directions;
    RaycastHit [] hits;
    public Ray wallPath;
    TimeManager timmywimmy;
    // Start is called before the first frame update
    void Start()
    {
        isWallRunning = false;
        OnWall = false;

        directions = new Vector3[]{
            Vector3.right,
            Vector3.left
        } ;
        timmywimmy = GameObject.FindGameObjectWithTag("GameController").GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {   
        hits = new RaycastHit[directions.Length];
        for (int i = 0; i< directions.Length; i++)
        {
            Vector3 dir = transform.TransformDirection(directions[i]);
            Physics.Raycast(transform.position,dir,out hits[i],wallDist);
            Debug.DrawRay(transform.position,dir,Color.red);
            foundWall = Physics.Raycast(transform.position,dir,out hit,2f);
            checkDirection(hit);
        }
            
        if(Input.GetKeyDown(KeyCode.R) && !playerCC.isGrounded){
            isWallRunning = true;
            //Debug.Log(wallPath);
        }   

        if(isWallRunning){
            isOnWall();
            wallRun(wallPath);
            //timmywimmy.DoSlowMo();
        } 
            
        if(isWallRunning && !OnWall){
            GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward));
        }
        if(playerCC.isGrounded || !OnWall){
            isWallRunning = false;
        }  
        
    }

    void checkDirection(RaycastHit _hit){
        
        if(foundWall && hit.collider.gameObject.layer == 10){
            float _angnile = Vector3.Angle(transform.TransformDirection(Vector3.forward),wallPath.direction);
            
            if(_angnile < 90f){
                wallPath = new Ray(_hit.point,Vector3.Cross(_hit.normal,Vector3.up).normalized ); 
            }
            else{
                    wallPath = new Ray(_hit.point,Vector3.Cross(_hit.normal,Vector3.up).normalized*-1 ); 
            }
            Debug.DrawRay(_hit.point,Vector3.Cross(_hit.normal,Vector3.up).normalized,Color.red);
        }
    }
    void isOnWall(){
        if(foundWall && !playerCC.isGrounded){
            OnWall = true;
            isWallRunning = true;
            playerCC.GetComponent<PlayerMovement>().gravity = 0f;           
        }
        else{
            OnWall = false;
            isWallRunning = false;
            playerCC.GetComponent<PlayerMovement>().gravity = -10f;
        }
    }

    void wallRun(Ray _dir){
        
             //playerCC.GetComponent<PlayerMovement>().gravity = 0f;
            playerCC.SimpleMove(Vector3.zero);
            playerCC.Move(_dir.direction * speed * Time.deltaTime);
        
    }
}
