using UnityEngine;
using System.Collections;

public class Timer{
	public	bool  _timer_running = false;
	public 	float _timer_timeout = 2.0f;
	private float _timer_start = 0.0f;
	
	
	
	public void start_timer(){
		_timer_start = Time.realtimeSinceStartup;
		_timer_running = true;
	}
	
	public void stop_timer(){
		_timer_start = 0.0f;
		_timer_running = false;
	}
	
	public float check_timer(){
		return (_timer_running) ? (_timer_start + _timer_timeout) - Time.realtimeSinceStartup : 0;
	}
}

