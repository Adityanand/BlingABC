using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play2 : MonoBehaviour
{
    public GameObject Shuffle;
    public Timer2 time;
    public bool play = false;
    public void OnPlay()

    {
        GameObject GameObject = GameObject.Find("Main Camera");
        GameObject.GetComponent<Timer2>().enabled = true;
        GameObject.GetComponent<UIElementDragger2>().enabled = true;
        GameObject.GetComponent<AudioSource>().enabled = true;
        Shuffle.GetComponent<Button>().enabled = false;
        play = true;
        if (play )
        {
          
            Time.timeScale = 1;
            
       }
    }
}
