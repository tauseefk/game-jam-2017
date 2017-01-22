using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devil : MonoBehaviour {

    Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Click", true);
        }
    }

    public void AnimationEnd()
    {
        print("HELLO!");
        animator.SetBool("Click", false);
    }
}
