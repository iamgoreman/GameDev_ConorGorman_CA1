using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon
{
    // Start is called before the first frame update
    Animator anim;
    public BoxCollider axeEdge;
    
    void Start()
    {
        found = true;
        held = true;
        anim = GetComponent<Animator>();
        axeEdge = GetComponent<BoxCollider>();
        axeEdge.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Fire(){
        anim.Play("AxeSwing");
        
    }

    private void OnCollisionEnter(Collision col) {
        if(col != null){
            Foe foe = col.gameObject.GetComponent<Foe>();
            if(foe != null){
                foe.takeDamage(damage);
            }
        }
    }
}
