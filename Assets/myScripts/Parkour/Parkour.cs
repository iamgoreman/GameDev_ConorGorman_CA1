using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parkour : MonoBehaviour
{
    // Start is called before the first frame update
    float range = .5f;
    float rotationSpeed = 250f;
    bool flipping = false;
    bool landed = true;
    Quaternion rot;
    Camera cammy;
    public GameObject player;
    Rigidbody riggy;
    TimeManager timmywimmy;
        void Start()
    {
        cammy = FindObjectOfType<Camera>();
        riggy = gameObject.GetComponent<Rigidbody>();
        timmywimmy = GameObject.FindGameObjectWithTag("GameController").GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(rotationSpeed*Time.deltaTime *-1,0,0);
        
        if(Input.GetKeyUp(KeyCode.Q)){
            Ray ray = cammy.ViewportPointToRay(new Vector3(.5f,.5f,0));
            RaycastHit hit; 
            
            if(Physics.Raycast(ray, out hit,range)){
                
                if(hit.transform.parent.name == "environ"){
                    rot = transform.rotation;
                    Vector3 _result = (hit.point - player.transform.position) *-4;
                    _result = _result - new Vector3(0,-5,0);
                    riggy.AddForce(_result,ForceMode.Impulse);
                    flipping = true;
                }

                if(hit.transform.tag =="Wall"){
                    float _angle = Vector3.Angle(hit.normal,Vector3.forward);

                    if(Mathf.Approximately(_angle,90)){
                        
                    }
                }

            }

        }
        

        if(player.transform.parent.GetComponent<Movement>().isGrounded()){
            Debug.Log("nailed it");
            flipping = false;
            //resetRotation();
        }
        
    }

    // void resetRotation(){
        
    //     transform.rotation = Quaternion.Euler(0f,rot.y,rot.z);

    // }
}
