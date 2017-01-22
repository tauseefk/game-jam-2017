using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScript : MonoBehaviour {

    [SerializeField]
    AudioSource audioSrc;

    [SerializeField]
    float time;

	// Use this for initialization
	void Start () {
        audioSrc = GetComponent<AudioSource>();

        if(time == 0)
        {
            time = GameState.audioTime;
        }

        audioSrc.time = time;
        // Start audio at correct time with last scene
        audioSrc.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
