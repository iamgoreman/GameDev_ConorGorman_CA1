using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public Text healthPanel;
    //Sets default health to 100
    public int health = 100;
    CharacterController caccy;
    private void Start()
    {
        //Sets the health text at the start, we pass 0 as we don’t want to remove health.
        //ApplyDamage(0);
        caccy = GetComponent<CharacterController>();
        health = GetComponent<Player>().health;
    }

    
    public void ApplyDamage(int damage)
    {
        //Checks we has attached a health panel and out health is greater than 0
        if (health > 0)
        {
            
            //Stores the current health and subtracts the damage value
            GetComponent<Player>().health -= damage;
            
            Debug.Log(health);
            caccy.SimpleMove(transform.TransformDirection(Vector3.back) * 50);
            //Sets the text on our panel.
            //healthPanel.text = health.ToString();
        }
    }
}
