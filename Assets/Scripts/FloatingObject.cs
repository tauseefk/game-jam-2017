using UnityEngine;
using System.Collections;

public class FloatingObject : MonoBehaviour {

	void Start() {
		
	}

	void Update() {
		transform.position = new Vector3(transform.position.x, transform.position.y + calculateSurfacePosition (transform.position.x), transform.position.z);	
	}

	public float calculateSurfacePosition (float x) {
		float t = Time.time;
		Debug.Log ((Mathf.Sin (x * 1.0f + t * 1.0f) + Mathf.Sin (x * 2.3f + t * 1.5f) + Mathf.Sin (x * 3.3f + t * 0.4f)) / 3.0f);
		return (Mathf.Sin(x * 1.0f + t * 1.0f) + Mathf.Sin(x * 2.3f + t * 1.5f) + Mathf.Sin(x * 3.3f + t * 0.4f)) / 3.0f;
	}

}