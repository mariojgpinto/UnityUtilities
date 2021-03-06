﻿using UnityEngine;
using System.Collections;

public class StopWatch{
	private	int 	_status = 0;

	private float 	_startTime = 0.0f;

	private float 	_pauseStartTime = 0.0f;
	private float 	_pausedTime = 0.0f;
	private float 	_pauseDelta = 0.0f;
	
	
	
	public void Run(){
		_startTime = Time.realtimeSinceStartup;
		_pauseDelta = 0;
		_status = 1;
	}
	
	public void Reset(){
		_startTime = 0.0f;
		_pauseDelta = 0;
		_status = 0;
	}

	public void Pause(){
		_pauseStartTime = Time.realtimeSinceStartup;
		_pausedTime = (_pauseStartTime - _startTime) - _pauseDelta;
		_status = 2;
	}

	public void Resume(){
		_pauseDelta += Time.realtimeSinceStartup - _pauseStartTime;
		_status = 1;
	}

	public float CheckTime(){
		return 	(_status == 1) ? (Time.realtimeSinceStartup - _startTime) - _pauseDelta : 
				(_status == 2) ? _pausedTime : 
				0;
	}
}

