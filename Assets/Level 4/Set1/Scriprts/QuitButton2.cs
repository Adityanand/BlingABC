using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton2 : MonoBehaviour {
    public GameObject MainCamera;
    public bool quit = false;
    public bool play = false;
    public void Quit () {
        MainCamera.GetComponent<UIElementDragger2>().enabled = false;
        MainCamera.GetComponent<Timer2>().enabled = false;
        GameObject QuitPopUp = GameObject.Find("QuitPopUp");
        QuitPopUp.GetComponent<Canvas>().enabled = true;
        quit = true;
        if (quit)
        {

            Time.timeScale = 0;

        }
    }
    public void Resume()
    {
        MainCamera.GetComponent<UIElementDragger2>().enabled = true;
        MainCamera.GetComponent<Timer2>().enabled = true;
        GameObject QuitPopUp = GameObject.Find("QuitPopUp");
        QuitPopUp.GetComponent<Canvas>().enabled = false;
        quit = false;
        play = true;
        if (play)
        {

            Time.timeScale = 1;

        }
    }
}
