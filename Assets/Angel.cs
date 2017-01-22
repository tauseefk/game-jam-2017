using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel : MonoBehaviour {

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Click", true);
        }
	}

    void AnimationEnd()
    {
        animator.SetBool("Click", false);
    }
}
