using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAnim : MonoBehaviour
{
    Animator axeAnim;
    // Start is called before the first frame update
    void Start()
    {
        axeAnim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        axeAnim.Play("AxeSwing");
    }
}
