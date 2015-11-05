using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	#region VARIABLES
	public static Controller instance;

	public enum GAME_STATUS{
		STOPPED,
		PLAYING,
		PAUSED
	};
	public static GAME_STATUS gameStatus = GAME_STATUS.STOPPED;
	int highScore;

	#endregion



	#region GAME_CALLBACKS
	public void StartGame(){
		Score.ResetScore();
		
		if(AudioController.isMute){
//			GUI_Start.sound_Button.isOn = true;
		}else{
//			GUI_Start.sound_Button.isOn = false;
		}

		gameStatus = GAME_STATUS.PLAYING;
	}	
	
	public void PauseGame(){

		gameStatus = GAME_STATUS.PAUSED;
	}
	
	public void UnPauseGame(){
		
		gameStatus = GAME_STATUS.PLAYING;
	}
	
	public void GameOver(){		
		highScore = Score.SaveScore();
		//GUI_Start.score_Text.text = "HIGHSCORE>" + highScore;
		
		if(highScore == Score.GetScore() && Score.GetScore() != 0){
//			GUI_GameOver.highScore_Image_gameObject.SetActive(true);
		}
		else{
//			GUI_GameOver.highScore_Image_gameObject.SetActive(false);
		}		
	}
	
	public void StopGame(){

		gameStatus = GAME_STATUS.STOPPED;
	}
	
	public void RestartGame(){
		StopGame();
		StartGame();
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
