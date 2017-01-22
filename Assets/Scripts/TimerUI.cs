﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour {

	[SerializeField]
	private Text _timerLabel;

	[SerializeField]
	private GameObject _transitionCanvas;

	[SerializeField]
	private GameObject _neuronContainer;

    [SerializeField]
    AudioSource _bgAudioSrc;

	[SerializeField]
	private float _timerLength = 30F;

	private float _startTime;

	private float _timeRemaining;

	private GameObject[] _neurons;

	private float _scoreCount = 0F;

	private Coroutine _scoreCoroutine;

	[SerializeField]
	private int _playerNumber = 1;

	[SerializeField]
	private Renderer _playerRend;

	void Start() {
		_startTime = Time.time;
		_timeRemaining = _timerLength;
		_neurons = GameObject.FindGameObjectsWithTag ("Target");
	}

	void Update() {
		if (_timeRemaining > 0) {
			_timeRemaining = _timerLength - Mathf.Floor (Time.time - _startTime);
		} else {
			if (_scoreCoroutine == null) {
				_scoreCoroutine = StartCoroutine (CalculateScore());
			}
			_transitionCanvas.SetActive (true);
		}
        // Save current position of audio
        GameState.audioTime = _bgAudioSrc.time;
        //update the label value
        _timerLabel.text = string.Format("{0:00} : {1:00}", "00", _timeRemaining);
	}

	IEnumerator CalculateScore() {
		foreach (GameObject neuron in _neurons) {
			if (neuron.GetComponent<Renderer> ().material.color == _playerRend.sharedMaterial.color) {
				if (_playerNumber == 1) {
					GameState.incrementDevilScore ();
				} else {
					GameState.incrementAngelScore ();
				}
			}
		}
		if (_playerNumber == 1) {
			Debug.Log (GameState.devilScore);
		} else {
			Debug.Log (GameState.angelScore);
		}
		yield return null;
	}
}
