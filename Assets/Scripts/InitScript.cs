using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InitScript : MonoBehaviour {

    [SerializeField]
    Image img;

    [SerializeField]
    Material instructions;

    bool showingInstructions;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
        if(Input.GetKeyDown(KeyCode.Space) && showingInstructions)
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !showingInstructions)
        {
            img.material = instructions;
            showingInstructions = true;
        }
    }
}
