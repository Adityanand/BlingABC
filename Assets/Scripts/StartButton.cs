using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {
   public float times;
   public float time;
   public float TimeLeft;
   public GameObject start;
    // Use this for initialization
    void Start () {
        times = 15;
        time = 1;
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft = times - Time.time;
        if ((TimeLeft <= 0))
        {
            start.GetComponent<Button>().enabled = true;
            start.GetComponent<Animator>().enabled = true;
        }
    }        

}
