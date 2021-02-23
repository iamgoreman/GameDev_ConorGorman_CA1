using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
    //public Transform start;
    public List<Transform> stopPoints;
    //public Transform end;
    public float speed;
    float journeyLength, startTime;

    bool touching,pressed,lockedIn;
    Transform currentPos;
    int currentIndex;

    // Start is called before the first frame update
   void Start()
   {
       startTime = Time.deltaTime;
       currentPos = stopPoints[0];
       currentIndex = stopPoints.IndexOf(stopPoints[0]);
       //journeyLength = Vector3.Distance(stopPoints[0].position,stopPoints[1].position);
   }

    // Update is called once per frame
    void Update()
    {
        
        if(touching == true && Input.GetKeyDown(KeyCode.E)){
            pressed = true;
            //Debug.Log("click");
            if(stopPoints[currentIndex+1] == null){
                Debug.Log("blunk");
                Transform _tempTrans = stopPoints[currentIndex-1];
                _tempTrans = stopPoints[currentIndex -1];
                stopPoints[0] = stopPoints[1];
                stopPoints[1] = _tempTrans;
            }
        }

        if(pressed== true){
            if(startTime< Time.time && lockedIn == false){
                startTime = Time.time;
                journeyLength = Vector3.Distance(stopPoints[currentIndex].position,stopPoints[currentIndex +1].position);
                lockedIn = true;
            }
            
            float distCovered = (Time.time - startTime) *speed;
            float fracOfJourney = distCovered/journeyLength;
            transform.position = Vector3.Lerp(stopPoints[currentIndex].position,stopPoints[currentIndex +1].position,fracOfJourney);
        }
        if(transform.position == stopPoints[currentIndex+1].position && pressed == true){
            pressed = false;
            lockedIn = false;
            currentIndex++;
            Debug.Log("Ding");
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
