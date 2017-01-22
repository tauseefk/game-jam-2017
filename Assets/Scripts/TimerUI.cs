using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour {

	[SerializeField]
	private Text _timerLabel;

	[SerializeField]
	private float _timerLength = 30F;

	private float _startTime;

	private float _timeRemaining;

	void Start() {
		_startTime = Time.time;
		_timeRemaining = _timerLength;
	}

	void Update() {
		Debug.Log (_timerLength);
		Debug.Log(Time.time - _startTime);
		_timeRemaining = _timerLength - Mathf.Floor(Time.time - _startTime);

		//update the label value
		_timerLabel.text = string.Format("{0:00} : {1:00}", "00", _timeRemaining);
	}
}
