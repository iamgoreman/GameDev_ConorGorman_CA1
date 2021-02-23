using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public float knockbackTime = 1;
    public float kick = 1.8f;
    private Transform goal;
    private NavMeshAgent agent;
    private bool hit;
    private ContactPoint contact;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        //set timer to the same knockback in first instance
        timer = knockbackTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (hit) {
            //allow physics to be applied
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            //Stop our AI navigation.
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            //Push back our enemy with an impulse force set via the kick value.
            gameObject.GetComponent<Rigidbody>().AddForceAtPosition(Camera.main.transform.forward * kick, contact.point, ForceMode.Impulse);
            hit = false;
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
            //After being knocked back, restart movement after X seconds.
            if (knockbackTime < timer)
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.GetComponent<NavMeshAgent>().isStopped = false;
                //update destination for enemy
                agent.SetDestination(goal.position);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //We compare the tag in the other object to the tag name we set earlier.
        if (other.transform.CompareTag("Bullet"))
        {
            contact = other.contacts[0];
            hit = true;
        }
    }
}
