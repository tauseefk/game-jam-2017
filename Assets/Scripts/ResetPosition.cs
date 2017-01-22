using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour {

	[SerializeField]
	private float _seconds = 2F;

	private Coroutine _deleting;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(_deleting == null)
		_deleting = StartCoroutine (DeleteAfterSeconds (_seconds));
	}

	IEnumerator DeleteAfterSeconds (float seconds) {
		yield return new WaitForSeconds (seconds);
		GetComponent<Shrink> ().enabled = true;
	}

	void OnCollisionEnter( Collision other ) {
		if (LayerMask.NameToLayer ("Boundary") == other.gameObject.layer || LayerMask.NameToLayer ("Targets") == other.gameObject.layer || LayerMask.NameToLayer ("Projectile") == other.gameObject.layer) {
 			GetComponent<Shrink> ().enabled = true;
		}
	}
}
