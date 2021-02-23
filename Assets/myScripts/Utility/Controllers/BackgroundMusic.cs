using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic bgm;
    public bool soundSwitch = true;
    public Toggle soundToggle; 
    // Start is called before the first frame update
    private void Awake()
    {
        if(bgm != null && bgm != this){
            Destroy(this.gameObject);
            return;
        }
        bgm = this;
        //DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause(){
        bgm.GetComponent<AudioSource>().Pause();
        }

    public void Resume(){
        bgm.GetComponent<AudioSource>().Play();
    }

    public void SoundButton(){
        if(soundSwitch){
            Pause();
            soundSwitch = false;
            soundToggle.isOn = false;
        }
        else{
            Resume();
            soundSwitch = true;
            soundToggle.isOn = true;
        }
    }
}
