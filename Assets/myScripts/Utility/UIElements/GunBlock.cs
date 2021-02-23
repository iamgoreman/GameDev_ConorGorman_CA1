using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunBlock : MonoBehaviour
{
    public TextMeshProUGUI ammoCount;
    public TextMeshProUGUI gunName;
    public GameObject gun;
    public bool found = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gun.GetComponent<Gun>().found){
            found = true;
        }

        ammoCount.text = gun.GetComponent<Gun>().currentAmmo.ToString();
    }
}
