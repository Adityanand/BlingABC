using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play1 : MonoBehaviour
{
    public GameObject Shuffle;
    public Timer1 time;
    public bool play = false;
    public void OnPlay()

    {
        GameObject GameObject = GameObject.Find("Main Camera");
        GameObject.GetComponent<Timer1>().enabled = true;
        GameObject.GetComponent<UIElementDragger>().enabled = true;
        GameObject.GetComponent<AudioSource>().enabled = true;
        Shuffle.GetComponent<Button>().enabled = false;
        play = true;
        if (play )
        {
          
            Time.timeScale = 1;
            
       }
    }
}
