using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMovie : MonoBehaviour {

    MovieTexture mt;
    AudioSource audioSrc;

    float timeLeft = 11.0f;

	// Use this for initialization
	void Start () {

        RawImage rim = GetComponent<RawImage>();
        audioSrc = GetComponent<AudioSource>();
        
        mt = (MovieTexture)rim.mainTexture;

        audioSrc.clip = mt.audioClip;

        audioSrc.Play();
        mt.Play();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            audioSrc.Stop();
        }
    }
}
