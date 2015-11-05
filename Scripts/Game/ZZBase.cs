using UnityEngine;
using System.Collections;

public class ZZBase : MonoBehaviour {
	#region VARIABLES
	public static ZZBase instance;
	
	#endregion
	
	
	
	#region GAME_CALLBACKS
	public void StartGame(){

	}
	
	public void PauseGame(){

	}
	
	public void UnPauseGame(){

	}
	
	public void GameOver(){

	}
	
	public void StopGame(){

	}
	
	public void RestartGame(){

	}
	#endregion
	
	
	
	#region UNITY_CALLBACKS
	// Use this for initialization
	void Awake () {
		instance = this;
	}
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	#endregion
}
