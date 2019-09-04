using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pause2 : MonoBehaviour
{
    public Timer2 time;
    public bool pause = false;
    public void OnPause()
    {
        GameObject GameObject = GameObject.Find("Main Camera");
        GameObject.GetComponent<UIElementDragger2>().enabled = false;
        pause = true;
        if (pause)
        {
            Time.timeScale = 0;
        }
    }
}
   