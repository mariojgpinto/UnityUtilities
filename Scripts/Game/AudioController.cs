using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
	#region VARIABLES
	public static AudioController 		instance;
	
//	public static AudioSource 			idle;
//	public static AudioClip 			idleClip;
	
	public static bool isMute = false;
	#endregion


	public static void Mute(){
		//		idle.volume = 0f;
		
		isMute = true;
	}
	
	public static void UnMute(){
		//		idle.volume = 1f;
		
		isMute = false;
	}
	
	#region UNITY_CALLBACKS
	// Use this for initialization
	void Awake () {
		AudioController.instance = this;
		//		idle	  = this.gameObject.AddComponent <AudioSource>();
		//		idleClip  = Resources.Load ("Audio/ambient") as AudioClip;
		//		idle.clip = idleClip;
		//		idle.loop = true;
		//		idle.Play();		
	}
	#endregion
}
