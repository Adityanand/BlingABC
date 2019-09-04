using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pause : MonoBehaviour
{
    public Timer time;
    public bool pause = false;
    public void OnPause()
    {
        GameObject GameObject = GameObject.Find("Main Camera");
        GameObject.GetComponent<UIElementDragger1>().enabled = false;
        pause = true;
        if (pause)
        {
            Time.timeScale = 0;
        }
    }
}
   