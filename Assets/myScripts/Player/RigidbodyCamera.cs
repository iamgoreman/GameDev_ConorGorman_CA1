using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyCamera : MonoBehaviour
{
    float minClamp = -40f;
    float maxClamp = 40f;
    public float lookSense;
    public Camera cammy;
    Vector2 rotation;
    Vector2 curRot;
    Vector2 rotationV = new Vector2(0, 0);
    public float lookSmoothDamp = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState =  CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // rotation.x += Input.GetAxis("Mouse X") * lookSense;
        // rotation.y += Input.GetAxis("Mouse Y") * lookSense;

        // rotation.y = Mathf.Clamp(rotation.x,minClamp,maxClamp);

        // transform.RotateAround(transform.position, Vector3.up, rotation.x);
        // cammy.transform.localEulerAngles = new Vector3(-rotation.y,0,0);
        rotation.x += Input.GetAxis("Mouse X") * lookSense;
        rotation.y += Input.GetAxis("Mouse Y") * lookSense;
        //clamping the values
    
        rotation.y = Mathf.Clamp(rotation.y, minClamp, maxClamp);
        //rotating the character based on the Mouse X
        transform.Rotate(Vector3.up * rotation.x);
        //smooth current Y rotation
        curRot.y = Mathf.SmoothDamp(curRot.y, rotation.y, ref rotationV.y, lookSmoothDamp);
        curRot.x = Mathf.SmoothDamp(curRot.x, rotation.x, ref rotationV.x, lookSmoothDamp);
        //update the camera X roation
        cammy.transform.localEulerAngles = new Vector3(-curRot.y, curRot.x, 0);

        if(Input.GetKeyDown(KeyCode.Escape)){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        cammy.transform.position = transform.position;
    }
}
