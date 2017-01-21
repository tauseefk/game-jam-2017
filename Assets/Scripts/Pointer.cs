using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {

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

    // Center of Atom
    Transform _center;

	// Use this for initialization
	void Start () {
		_center = _playerContainer;
        transform.position = (transform.position - _center.position).normalized * _radius + _center.position;
	}
	
	// Update is called once per frame
	void Update () {

        transform.LookAt(_playerContainer);

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(_center.position, _yAxis, _rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(_center.position, -(_yAxis), _rotationSpeed * Time.deltaTime);
		}

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.RotateAround(_center.position, _xAxis, _rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.RotateAround(_center.position, -(_xAxis), _rotationSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
			_playerAtom = Instantiate (_playerAtomPrefab, _playerContainer.parent);
			_playerAtomRB = _playerAtom.GetComponent<Rigidbody>();
            _playerAtomRB.AddForce((_center.position - transform.position).normalized * _atomForce);
        }
    }
}
