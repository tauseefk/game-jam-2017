using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScript : MonoBehaviour {

    [SerializeField]
    GameObject good, bad;

    RawImage rim;
    MovieTexture mt;

	// Use this for initialization
	void Start () {

        // Good won
        if (GameState.angelScore > GameState.devilScore)
        {
            good.SetActive(true);
            rim = good.GetComponent<RawImage>();
        }
        else
        {
            bad.SetActive(true);
            rim = bad.GetComponent<RawImage>();
        }

        mt = (MovieTexture)rim.mainTexture;
        mt.Play();
    }
}
