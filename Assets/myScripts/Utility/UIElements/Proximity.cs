using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Proximity : MonoBehaviour
{
    public string newTitle;
    public string newAuthor;
    public string newDesc;
    private Transform other;
    private Text myTitle;
    private Text myAuthor;
    private Text myDesc;
    private float dist;
    private GameObject player;
    private GameObject message1;
    private GameObject message2;
    private GameObject message3;
    public Camera cammy;
    private Ray ray;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        other = player.GetComponent<Transform>();
        message1 = GameObject.FindWithTag("ArtTitle");
        message2 = GameObject.FindWithTag("Auth");
        message3 = GameObject.FindWithTag("Description");
        myTitle = message1.GetComponent<Text>();
        myTitle.text = "";
        myAuthor = message2.GetComponent<Text>();
        myAuthor.text = "";
        myDesc = message3.GetComponent<Text>();
        myDesc.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (other)
        {
            ray = new Ray(transform.position,(other.position-transform.position));
            RaycastHit hit; 
            dist = Vector3.Distance(transform.position, other.position);
            if(Physics.Raycast(ray, out hit)){
               
                if (dist < 6 && hit.collider.tag == "Player" && IsVisibleFrom())
            {
                //Debug.Log("asdf");
                myTitle.text = newTitle;
                myAuthor.text = newAuthor;
                myDesc.text = newDesc;
            }



            }
           
           // print("Distance to player: " + dist);
            
        }

    }
    bool IsVisibleFrom(){

     Vector3 screenPoint = cammy.WorldToViewportPoint(transform.position);
     bool onScreen = screenPoint.z > 0 && screenPoint.x > -.5 && screenPoint.x < 1.5 && screenPoint.y > -0.5 && screenPoint.y < 1.5;
     return onScreen;   
    } 
}
