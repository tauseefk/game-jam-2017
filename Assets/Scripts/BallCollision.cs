using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour {

	[SerializeField]
	private Renderer _rend;
    private MeshRenderer _neuronRenderer;

    private Neuron _neuron;

	[SerializeField]
	private Renderer _playerRenderer;

	private float _elapsedTime = 0f;
	private Color _baseColor = Color.red;
	private Color _originalColor;
	private float _duration = 1.0F;

    private Color _originalNeuronColor;

	[SerializeField]
	private float _emission = 5.0f;
	[SerializeField]
	private float _speed = 1f;

	private Coroutine _collisionAnimation = null;
    private Coroutine _neuronCollisionAnimation = null;

	// Use this for initialization
	void Start () {
		_baseColor = _rend.material.color;
		_originalColor = _rend.material.color;
        _neuron = GetComponentInChildren<Neuron>();
        _neuronRenderer = _neuron.GetMeshRenderer();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other) {
		if (LayerMask.NameToLayer ("Projectile") == other.gameObject.layer) {
//			_playerRenderer = other.gameObject.GetComponent<Renderer>;
			Shrink shrinkScript = other.gameObject.GetComponent<Shrink> ();
			shrinkScript.enabled = true;
		}
		if (LayerMask.NameToLayer ("Targets") == other.gameObject.layer || LayerMask.NameToLayer ("Projectile") == other.gameObject.layer) {
			if (_collisionAnimation != null) {
				StopCoroutine (_collisionAnimation);
				//				_elapsedTime = 0f;
				_collisionAnimation = null;
			} else {
				Renderer otherRend = other.gameObject.GetComponent<Renderer> ();
				_originalColor = _rend.material.color;
				_collisionAnimation = StartCoroutine (TriggerCollisionAnimation (otherRend.material.color));
			}
            // Handling neuron layer
            if(_neuronCollisionAnimation != null)
            {
                StopCoroutine(_neuronCollisionAnimation);
                _neuronCollisionAnimation = null;
            } else
            {
                Renderer otherRend = other.gameObject.GetComponent<Renderer>();
                _originalNeuronColor = _neuron.GetMKGlowColor();
                _neuronCollisionAnimation = StartCoroutine(TriggerNeuronCollisionAnimation(otherRend.material.color));
            }
		}
	}

	IEnumerator TriggerCollisionAnimation (Color _targetColor)
	{
		while (_rend.material.color != _targetColor)
		{
			_elapsedTime += Time.deltaTime;
			float lerp = (_speed * _elapsedTime) / _duration;
//			if (lerp >= 0.5f)
//				yield break;
			_rend.material.color = Color.Lerp(_originalColor, _targetColor, lerp);
			yield return null;
		}
	}

    IEnumerator TriggerNeuronCollisionAnimation(Color _targetColor)
    {
        while (_neuronRenderer.material.color != _targetColor)
        {
            _elapsedTime += Time.deltaTime;
            float lerp = (_speed * _elapsedTime) / _duration;
            //			if (lerp >= 0.5f)
            //				yield break;
            _neuron.SetMKGlowColor(Color.Lerp(_originalNeuronColor, _targetColor, lerp));
            yield return null;
        }
    }
}
