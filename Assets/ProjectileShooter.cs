using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour {

	// Atom to fire
	GameObject _playerAtom;

	[SerializeField]
	GameObject _playerAtomPrefab;

	[SerializeField]
	Transform _playerContainer;

	Rigidbody _playerAtomRB;

	// Radius between pointer and player atom
	[SerializeField]
	float _radius;

	[SerializeField]
	float _radiusSpeed;

	// Reference pointers for rotation
	Vector3 _yAxis = Vector3.up;
	Vector3 _xAxis = Vector3.right;

	// Rotation speed of pointer
	[SerializeField]
	float _rotationSpeed;

	[SerializeField]
	float _atomForce;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			_playerAtom = Instantiate (_playerAtomPrefab, transform.parent);
			_playerAtomRB = _playerAtom.GetComponent<Rigidbody>();
			_playerAtomRB.AddForce((transform.forward).normalized * _atomForce);
		}
	}
}
