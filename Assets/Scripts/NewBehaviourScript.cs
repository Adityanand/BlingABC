using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    float Timer = 10;
    public Timer1 Time1;
    public bool Times=false;
    public void Update()
    {
        if (Time1.MatchedUpImage == true)
        {
            Times = true;
            GameObject Gameobject = GameObject.Find("Main Camera");
            
           
            GetComponent<Timer1>().enabled = false;
            
            Time1.times = Time1.timer - Time1.TimeLeft;
            
            GameObject Alarm = GameObject.Find("Canvas");
            Alarm.GetComponent<AudioSource>().enabled = false;
            if(Timer<-30)
            {
                Times = false;
                Time1.MatchedUp.GetComponent<AudioSource>().enabled = true;
                Gameobject.GetComponent<AudioSource>().enabled = false;
                Time1.MatchedUp.GetComponent<Canvas>().enabled = true;
                Time1.Finished.text = ("Well done! You got all matches done in " + Mathf.Floor(Time1.times) + " seconds.");
            }
            if(Times==true)
            {
                Timer--;

            }
        }
    }
}
