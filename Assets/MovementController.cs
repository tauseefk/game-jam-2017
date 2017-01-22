using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

	[SerializeField]
	private float _movementSpeed = 1F;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(GetComponentInChildren<Camera> ().transform.forward);
		if(Input.GetKey(KeyCode.LeftArrow))
		{
//			transform.RotateAround(_center.position, _yAxis, _rotationSpeed * Time.deltaTime);
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 0.1F * _movementSpeed);
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
//			transform.RotateAround(_center.position, -(_yAxis), _rotationSpeed * Time.deltaTime);
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - 0.1F * _movementSpeed);
		}

		if (Input.GetKey(KeyCode.UpArrow))
		{
//			transform.RotateAround(_center.position, _xAxis, _rotationSpeed * Time.deltaTime);
			transform.position = new Vector3 (transform.position.x + 0.1F * _movementSpeed, transform.position.y, transform.position.z);
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
//			transform.RotateAround(_center.position, -(_xAxis), _rotationSpeed * Time.deltaTime);
			transform.position = new Vector3 (transform.position.x - 0.1F * _movementSpeed, transform.position.y, transform.position.z);
		}
	}
}
