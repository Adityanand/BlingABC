using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour {
    public AudioClip sound;
    private Button play { get { return GetComponent<Button>(); } }
    private AudioSource Source { get { return GetComponent<AudioSource>(); } }

	// Use this for initialization
	void Start () {
        gameObject.AddComponent<AudioSource>();
        Source.clip = sound;
        Source.playOnAwake = false;
        play.onClick.AddListener(() => PlaySound());
	}
	
	// Update is called once per frame
	void PlaySound()
    {
        Source.PlayOneShot(sound);
    }
}
