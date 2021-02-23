using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPanel : MonoBehaviour
{
    public GameObject player;
    public Text health;
    // Start is called before the first frame update
    void Start()
    {
        health.text = player.GetComponent<Player>().health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        health.text = player.GetComponent<Player>().health.ToString();
    }
}
