using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public float mouseSpeed = 100f, tiltCeil;
    float tiltSpeed = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    Vector2 mouseLook;
    float inputValue;
    float tiltRamp = 1f;
    public bool active;
    
    void Start()
    {
        active = true;
        gameObject.SetActive(active);
        this.enabled = active;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()

    {
        //Debug.Log(PauseMenu.isPaused);
        mouseLook = new Vector2(Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime, Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime);

        xRotation -= mouseLook.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //tiltValue = Input.GetAxis("Horizontal");
        
        if(Input.GetKey(KeyCode.A)){
            //Debug.Log(Input.GetAxis("Horizontal")*tiltSpeed);
            tiltRamp -= 1f;
            //Debug.Log(tiltRamp);
            tiltRamp = Mathf.Clamp(tiltRamp, -tiltCeil, 0f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, -tiltRamp);


        }
        else if(Input.GetKey(KeyCode.D)){
            //Debug.Log(tiltValue);
            tiltRamp += 1f;
            tiltRamp= Mathf.Clamp(tiltRamp, 0f, tiltCeil);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, -tiltRamp);
        }
        else{
            //tiltRamp = 0f;
            ResetTilt();
            transform.localRotation = Quaternion.Euler(xRotation, 0f, -tiltRamp);

        }
        
        playerBody.Rotate(Vector3.up * mouseLook.x);

        
    }

    void ResetTilt(){
        if(tiltRamp < 0f){
            tiltRamp+= 2f;

        }

        else if(tiltRamp > 0f){
            tiltRamp-= 2f;
        }
        
        if(tiltRamp <1f && tiltRamp > -2f){
            tiltRamp = 0f;
        }

    }

    public void SwitchActivation(){
        active = !active;
        gameObject.SetActive(active);
        this.enabled = active;
    }

}
