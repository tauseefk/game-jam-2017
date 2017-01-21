using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour {

	[SerializeField]
	private GameObject _startNode;

	private Rigidbody _rb;

	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter (Collision other) {
		transform.position = _startNode.transform.position;
		_rb.velocity = new Vector3(0, 0, 0);
		_rb.angularVelocity = new Vector3(0, 0, 0);
	}
}
