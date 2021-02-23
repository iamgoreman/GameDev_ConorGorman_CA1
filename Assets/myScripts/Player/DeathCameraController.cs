using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCameraController : MonoBehaviour
{
    public GameObject player;
    bool active;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDir = player.transform.position - transform.position;
        float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step,0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    public void SwitchActivation(){
        active = !active;
        gameObject.SetActive(active);
        this.enabled = active;
        Vector3 resetRot = new Vector3(0,180f,0);
        transform.localEulerAngles = resetRot; 
    }

}
