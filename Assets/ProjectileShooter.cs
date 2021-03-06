﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour {

	// Atom to fire
	GameObject _playerAtom;

	[SerializeField]
	GameObject _playerAtomPrefab;

	Transform _playerContainer;

	Rigidbody _playerAtomRB;

    [SerializeField]
    AudioClip _blastSound;

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
		if(Input.GetMouseButton(0))
		{
            GetComponent<AudioSource>().PlayOneShot(_blastSound);
			_playerAtom = Instantiate (_playerAtomPrefab, transform.position, Quaternion.identity, transform.parent);
			_playerAtomRB = _playerAtom.GetComponent<Rigidbody>();
			_playerAtomRB.AddForce((gameObject.GetComponentInChildren<Camera>().transform.forward).normalized * _atomForce);
		}
	}
}
