using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawners : MonoBehaviour
{
    public GameObject go;
    public bool active;
    public Spawners(GameObject newGo, bool newBool)
    {
        go = newGo;
        active = newBool;
    }
}

public class GameManager : MonoBehaviour
{
    public GameObject panel;
    public delegate void RestartRounds();
    public static event RestartRounds RoundComplete;

    private int health;
    private int roundsSurvived;
    private int currentRound;
    private PlayerDamage playerDamage;
    private Text panelText;

    public List<Spawners> spawner = new List<Spawners>();

    //public List<GameObject> entityList = new List<GameObject>();

    void Awake() {
    }
    void Start()
    {
        
        if(!GetComponent<TimeManager>().isActiveAndEnabled){
            GetComponent<TimeManager>().enabled = true;
        }
        playerDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDamage>();
        panelText = panel.GetComponentInChildren<Text>();
        foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (go.name.Contains("Spawner"))
            {
                spawner.Add(new Spawners(go, false));
                go.SetActive(false);
            }
        }
        spawner[0].go.SetActive(true);

    }

    void Update()
    {

        int total = 0;
        health = playerDamage.health;
        if (health > 0)
        {
            for (int i = spawner.Count - 1; i >= 0; i--)
            {
                if (spawner[i].go.GetComponent<Spawner>().spawnsDead)
                {   
                    total++;
                }
            }
            if(spawner[0].go.GetComponent<Spawner>().spawnsDead){
                spawner[1].go.SetActive(true);
            }

            if(spawner[1].go.GetComponent<Spawner>().spawnsDead){
                spawner[2].go.SetActive(true);
            }
            if(spawner[2].go.GetComponent<Spawner>().spawnsDead){
                spawner[3].go.SetActive(true);
            }

            if(spawner[3].go.GetComponent<Spawner>().spawnsDead){
                SceneManager.LoadScene("Menu");
            }

            if (total == spawner.Count && roundsSurvived == currentRound)
            {
                roundsSurvived++;
                panelText.text = string.Format("{0}", roundsSurvived);
                panel.SetActive(true);
            }

            if (roundsSurvived != currentRound && Input.GetButtonUp("Fire2"))
            {
                currentRound = roundsSurvived;
                RoundComplete();
                panel.SetActive(false);
            }
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
     }
}
