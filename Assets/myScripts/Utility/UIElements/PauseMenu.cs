using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pausePanel,gunPanel,healthPanel,roundPanel;
    GameManager gm;
    
    void Start()
    {
        Resume();
        pausePanel.SetActive(false);
        gm = GameObject.FindObjectOfType<GameManager>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPaused){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else{
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                Resume();
            }

            else{
                Pause();
            }
        }
    }

    public void Resume(){
        pausePanel.SetActive(false);
        gunPanel.SetActive(true);
        healthPanel.SetActive(true);
        roundPanel.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void Pause(){
        pausePanel.SetActive(true);
        gunPanel.SetActive(false);
        healthPanel.SetActive(false);
        roundPanel.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuitToTitle(){
        gm.GetComponent<TimeManager>().enabled = false;
        Destroy(gm);
        SceneManager.LoadScene("Menu");
    }
}
