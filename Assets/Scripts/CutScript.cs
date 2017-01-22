using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScript : MonoBehaviour {

    [SerializeField]
    AudioSource audioSrc;

	// Use this for initialization
	void Start () {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.time = 11.0f;
        // Start audio at correct time with last scene
        audioSrc.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
