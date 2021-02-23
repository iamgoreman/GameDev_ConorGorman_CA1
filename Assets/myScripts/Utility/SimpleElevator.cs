using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleElevator : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform start;
    public Transform end;
    public float speed;
    float journeyLength, startTime,step;

    bool touching, pressed, lockedIn, flip;

    // Start is called before the first frame update
   void Start()
   {
       startTime = Time.deltaTime;
       journeyLength = Vector3.Distance(start.position,end.position);
   }

    // Update is called once per frame
    void Update()
    {
        
        if(touching == true && Input.GetKeyDown(KeyCode.E)){
            pressed = true;
        }

        if(pressed== true){
            // if(startTime< Time.time && lockedIn == false){
            //     startTime = Time.time;
            //     lockedIn = true;
            // }
            // float distCovered = (Time.time - startTime) *speed;
            // float fracOfJourney = distCovered/journeyLength;
            // transform.position = Vector3.Lerp(start.position,end.position,fracOfJourney);
            step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position,end.position,step);
        }

        if(transform.position == end.position && pressed == true){
            Transform _tempTrans = end;
            end = start;
            start = _tempTrans;

            pressed = false;
            lockedIn = false;
        }
    }
        
       private void OnCollisionEnter(Collision col) {
        if(col.gameObject.name == "PlayerCharacter" ){
            touching = true;

        } 
        else{
            touching = false;
        }
        
    } 
    
}
