using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour {
	#region VARIABLES
	public static string SCENE_MAIN = "MainMenu";
	public static string SCENE_TOWER_DEFENSE = "TowerDefense";

	#endregion

	#region SCENE_MANAGMENT
	public static void LoadScene(string lvl) {
		SceneManager.LoadScene(lvl);
	}

	public static void LoadMainScene() {
		Screen.orientation = ScreenOrientation.Portrait;
		SceneManager.LoadScene(SCENE_MAIN);
	}
	#endregion

	#region UI_CALLBACKS
	void OnButton_Menu(object sender, ButtonPressedEventArgs e) {
		switch (e.id) {
			case "towerDefense_Button": //MENU - TOWERDEFENSE
				Debug.Log(e.id + " - MENU - BUTTON TOWERDEFENSE");

				Screen.orientation = ScreenOrientation.Landscape;
				LoadScene(SCENE_TOWER_DEFENSE);
				break;
			case "exit_Button": //MENU - EXIT
				Debug.Log(e.id + " - MENU - BUTTON EXIT");
				Application.Quit();
				break;
			default: break;
		}
	}

	void AssignEvents() {
		GUI_Controller.RemoveAllEvents();

		GUI_Controller.GUI_Menu_ButtonPressed += OnButton_Menu;

	}
	#endregion

	#region UNITY_CALLBACKS
	// Use this for initialization
	void Start () {
		AssignEvents();
	}
	#endregion
}
