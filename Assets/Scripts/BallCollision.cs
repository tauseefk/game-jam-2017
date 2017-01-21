using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour {

	[SerializeField]
	private Renderer _rend;

	[SerializeField]
	private Renderer _playerRenderer;

	private float _elapsedTime = 0f;
	private Color _baseColor = Color.red;
	private Color _originalColor;
	private float _duration = 1.0F;

	[SerializeField]
	private float _emission = 5.0f;
	[SerializeField]
	private float _speed = 1f;

	private Coroutine _collisionAnimation = null;

	// Use this for initialization
	void Start () {
		_baseColor = _rend.material.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other) {
		if (LayerMask.NameToLayer("Player") == other.gameObject.layer) {
//			_playerRenderer = other.gameObject.GetComponent<Renderer>;
			if (_collisionAnimation != null) {
				StopCoroutine (_collisionAnimation);
				_elapsedTime = 0f;
				_collisionAnimation = null;
			} else {
				_collisionAnimation = StartCoroutine (TriggerCollisionAnimation (_playerRenderer.material.color));
			}
		}
	}

	IEnumerator TriggerCollisionAnimation (Color _targetColor)
	{
		while (_rend.material.color != _targetColor)
		{
			_elapsedTime += Time.deltaTime;
			float lerp = (_speed * _elapsedTime) / _duration;
			if (lerp >= 0.8f)
				yield break;
			_rend.material.color = Color.Lerp(_baseColor, _targetColor * _emission, lerp);
			yield return null;
		}
	}
}
