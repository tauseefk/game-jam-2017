using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour {

    [SerializeField]
    GameObject good, bad, credits;

    RawImage rim;
    MovieTexture mt;

    bool playedEnding, playedCredits;

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

    void Update()
    {
        // If player is not playing and ending hasnt been played
        if(!mt.isPlaying && !playedEnding)
        {
            playedEnding = true;

            // If ending has been played
            if(playedEnding)
            {
                if(!playedCredits)
                {
                    playedCredits = true;

                    good.SetActive(false);
                    bad.SetActive(false);
                    credits.SetActive(true);

                    rim = credits.GetComponent<RawImage>();
                    mt = (MovieTexture)rim.mainTexture;
                    mt.Play();
                }
            }
        }

        // If the ending and credits have been played
        if (!mt.isPlaying && playedEnding && playedCredits)
        {
            SceneManager.LoadScene(0);
        }
    }
}
