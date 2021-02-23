using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    int hitNumber;
     void OnCollisionEnter(Collision other) {
        if (other.transform.CompareTag("Bullet"))
        {
            //If the comparison is true, we increase the hit number.
            hitNumber++;
        }
        //if the hit number is equal to 3 we destroy this object.
        if (hitNumber == 3)
        {
            gameObject.SetActive(false);
        }
    }
}
