using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {

    // Atom to fire
    [SerializeField]
    GameObject _playerAtom;
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
        _center = _playerAtom.transform;
        transform.position = (transform.position - _center.position).normalized * _radius + _center.position;
        _playerAtomRB = _playerAtom.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        transform.LookAt(_playerAtom.transform);

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(_center.position, _yAxis, _rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(_center.position, -(_yAxis), _rotationSpeed * Time.deltaTime);        }

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
        if(Input.GetKey(KeyCode.Space))
        {
            _playerAtomRB.AddForce((_center.position - transform.position).normalized * _atomForce);
        }
    }
}
