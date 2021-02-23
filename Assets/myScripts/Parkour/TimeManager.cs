using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowDownFactor = 0.05f;
    public float slowDownLength = 2f;
    public GameObject player;
    // Start is called before the first frame update
    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");    
    }
    void Update()
    {
        if(player.GetComponent<WallRun>().isWallRunning){
            Time.timeScale += (1f/slowDownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale,0f,1f);
        }   
        
    }

    // Update is called once per frame
    public void DoSlowMo()
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}
