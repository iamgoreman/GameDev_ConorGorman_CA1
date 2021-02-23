using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunPanel : MonoBehaviour
{
    public List<GunBlock> GunBlocks = new List<GunBlock>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GunBlock block in GunBlocks)
        {
            if(block.found == false){
                block.gunName.enabled = false;
                block.ammoCount.enabled = false;
            }

            else{
                block.gunName.enabled = true;
                block.ammoCount.enabled = true;
            }
        }
    }
}
