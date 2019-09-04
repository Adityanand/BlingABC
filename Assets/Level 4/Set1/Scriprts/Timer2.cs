using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer2 : MonoBehaviour {
    public Text TimeText;
    public Text StarCount;
    public Text Finished;
    public int Stars=0;
    public float times;
    public GameObject MatchedImage1;
    public GameObject MatchedImage2;
    public GameObject MatchedImage3;
    public GameObject MatchedImage4;
    public GameObject OneStar;
    public GameObject TwoStar;
    public GameObject ThreeStar;
    public GameObject FourStar;
    public GameObject Star11;
    public GameObject Star22;
    public GameObject Star33;
    public GameObject Star44;
    public GameObject Camera;
    public GameObject MatchedUp;
    public float TimeStamp;
    public bool UsingTimer = false;
    public float TimeLeft;
    public float timer;
    public bool MatchedUpImage = false;
    // Use this for initialization
    void Start () {
      SetTimer(30);
    timer=30;
      
	}
	
	// Update is called once per frame
	void Update () {
       //if (UsingTimer)
            SetUIText();
        if((MatchedImage1.GetComponent<Image>().enabled==true)&&(MatchedImage2.GetComponent<Image>().enabled==true)
            && (MatchedImage3.GetComponent<Image>().enabled == true) && (MatchedImage4.GetComponent<Image>().enabled == true))
        {
            MatchedUpImage = true;
        }
       if ((MatchedImage1.GetComponent<Image>().enabled == true)|| (MatchedImage2.GetComponent<Image>().enabled == true)||
            (MatchedImage3.GetComponent<Image>().enabled == true)|| (MatchedImage4.GetComponent<Image>().enabled == true))
        {
            Stars = 1;
            Star11.GetComponent<Image>().enabled = true;
        }
        if ((MatchedImage2.GetComponent<Image>().enabled == true)&& (MatchedImage1.GetComponent<Image>().enabled == true)|| (MatchedImage1.GetComponent<Image>().enabled == true)&&(MatchedImage3.GetComponent<Image>().enabled == true)|| (MatchedImage1.GetComponent<Image>().enabled == true)&& (MatchedImage4.GetComponent<Image>().enabled == true)||
            (MatchedImage2.GetComponent<Image>().enabled == true)&& (MatchedImage3.GetComponent<Image>().enabled == true)|| (MatchedImage2.GetComponent<Image>().enabled == true)&& (MatchedImage4.GetComponent<Image>().enabled == true)|| (MatchedImage2.GetComponent<Image>().enabled == true)&& (MatchedImage3.GetComponent<Image>().enabled == true)||
            (MatchedImage2.GetComponent<Image>().enabled == true)&&(MatchedImage4.GetComponent<Image>().enabled == true)|| (MatchedImage3.GetComponent<Image>().enabled == true)&&(MatchedImage4.GetComponent<Image>().enabled == true))
        {
            Stars = 2;
            Star22.GetComponent<Image>().enabled = true;
        }
        if ((MatchedImage1.GetComponent<Image>().enabled == true)&&(MatchedImage2.GetComponent<Image>().enabled == true)&&(MatchedImage3.GetComponent<Image>().enabled == true)|| (MatchedImage2.GetComponent<Image>().enabled == true)&& (MatchedImage3.GetComponent<Image>().enabled == true)&& (MatchedImage4.GetComponent<Image>().enabled == true)||
            (MatchedImage3.GetComponent<Image>().enabled == true)&& (MatchedImage4.GetComponent<Image>().enabled == true)&& (MatchedImage1.GetComponent<Image>().enabled == true))
        {
            Stars = 3;
            Star33.GetComponent<Image>().enabled = true;
        }
        if ((MatchedImage2.GetComponent<Image>().enabled == true) && (MatchedImage2.GetComponent<Image>().enabled == true) && (MatchedImage3.GetComponent<Image>().enabled == true)&&(MatchedImage4.GetComponent<Image>().enabled == true))
        {
            Stars = 4;
           Star44.GetComponent<Image>().enabled = true;
        }
            /*if (ThreeStar.GetComponent<Image>().enabled == true)
            {
                Stars = 3;
                Star33.GetComponent<Image>().enabled = true;
            }
            if (FourStar.GetComponent<Image>().enabled == true)
            {
                Stars = 4;
                Star44.GetComponent<Image>().enabled = true;
            }*/
            /*if(MatchedUpImage==true)
            {
                GameObject Gameobject = GameObject.Find("Main Camera");
                Gameobject.GetComponent<AudioSource>().enabled = false;
                MatchedUp.GetComponent<Canvas>().enabled = true;
                GetComponent<Timer1>().enabled = false;
                MatchedUp.GetComponent<AudioSource>().enabled = true;
                times = timer - TimeLeft;
                Finished.text = ("Well done! You got all matches done in " + Mathf.Floor(times) + " seconds.");
                GameObject Alarm = GameObject.Find("Canvas");
                Alarm.GetComponent<AudioSource>().enabled = false;
            }*/

        }
  public void SetTimer(float time)
    {
        if (UsingTimer)
            return;
        TimeStamp = Time.time + time;
        UsingTimer = true;
    }
    public void SetUIText()
    {
        if (UsingTimer)
            TimeLeft = TimeStamp - Time.time;
        if (TimeLeft < 6)
        {
            GameObject Alarm = GameObject.Find("Canvas");
            Alarm.GetComponent<AudioSource>().enabled = true;
        }
        if (TimeLeft<=0)
        {
            Finish();

            if (TimeLeft <= 0)
            {
                GameObject Canvas = GameObject.Find("Time'sPopUP");
                Canvas.GetComponent<Canvas>().enabled = true;
                if (Stars <= 1)
                {
                    StarCount.text = ("You completed " + Stars + " match in 15 seconds.");
                }
                else
                {
                    StarCount.text = ("You completed " + Stars + " matches in 15 seconds.");
                }
                Camera.GetComponent<UIElementDragger2>().enabled = false;
                GameObject Gameobject = GameObject.Find("Main Camera");
                Gameobject.GetComponent<AudioSource>().enabled = false;
                Canvas.GetComponent<AudioSource>().enabled = true;
                GameObject Alarm = GameObject.Find("Canvas");
                Alarm.GetComponent<AudioSource>().enabled = false;

            }
            return;
        }
        float hours;
        float minutes;
        float seconds;
      
        GetTimeValues(TimeLeft, out hours, out minutes, out seconds);
        if (hours>0)
            TimeText.text = string.Format("{0}{0}:{1}", hours,minutes);
      
        else if (seconds<10)
        
            TimeText.text = string.Format("{0}{0}:{0}{1}", minutes, seconds);
        
        else
          TimeText.text = string.Format("{0}{0}:{1}", minutes, seconds);

    }
    public void GetTimeValues(float time,out float hours,out float minutes, out float seconds)
    {
        hours = (int)(time / 3600f);
        minutes = (int)((time - hours * 3600) / 60f);
        seconds = (int)((time - hours * 3600-minutes* 60));
      
    }
    public void Finish()
    {
       
        TimeText.text = "00:00";
        UsingTimer = false;
    }
}
