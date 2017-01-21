using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : MonoBehaviour {


	[SerializeField]
	private float shrinkSpeed = 10f;
	// Use this for initialization
	void Start () {
		StartCoroutine(ShrinkOut());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator ShrinkOut ()
	{
		//        yield return new WaitForSeconds(25f);
		while(transform.localScale.x >= 0)
		{
			transform.localScale = new Vector3 (transform.localScale.x - 0.01F * shrinkSpeed, transform.localScale.y - 0.01F * shrinkSpeed, transform.localScale.z - 0.01F * shrinkSpeed);
			yield return new WaitForSeconds(.01f);
		}

		if(transform.localScale.x <= 0)
		{
			Destroy(gameObject);
		}
	}
}
