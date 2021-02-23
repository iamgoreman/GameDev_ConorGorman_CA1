using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject player;
    private float minClamp = -20;
    private float maxClamp = 30;

    [HideInInspector]
    public Vector2 rotation;
    private Vector2 currentLookRot;
    private Vector2 rotationV = new Vector2(0, 0);

    public float lookSensitivity = 2;
    public float lookSmoothDamp = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        //get the game Player object
        player = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        //Input from mouse
        rotation.y += Input.GetAxis("Mouse Y") * lookSensitivity;
        //clamping the values
        rotation.y = Mathf.Clamp(rotation.y, minClamp, maxClamp);
        //rotating the character based on the Mouse X
        player.transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * lookSensitivity);
        //smooth current Y rotation
        currentLookRot.y = Mathf.SmoothDamp(currentLookRot.y, rotation.y, ref rotationV.y, lookSmoothDamp);

        //update the camera X roation
        transform.localEulerAngles = new Vector3(-currentLookRot.y, 0, 0);
    }
}
