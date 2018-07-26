using UnityEngine;
using System;
using System.IO;
using System.Collections;

using MPAssets;

[Prefab("GUI_Controller", false)]
public class GUI_Controller : Singleton<GUI_Controller> {
	#region VARIABLES
	public GameObject gui_Menu;

	public static event EventHandler<ButtonPressedEventArgs> GUI_Menu_ButtonPressed;

	#endregion

	#region SETUP
	void FindGameObjects(){
		for(int i = 0 ; i < this.transform.childCount ; ++i){
			GameObject go = this.transform.GetChild(i).gameObject;

			switch(go.name){
				case "Panel_Menu":
					gui_Menu = go;
					break;
				default: break;
			}
		}
	}

	void InitializeClasses(){
		gui_Menu.GetComponent<RectTransform>().localPosition = Vector3.zero;

		GUI_Menu.UpdateValues(gui_Menu);
		gui_Menu.gameObject.SetActive(true);
	}

	void InitializeListeners(){
		GUI_Menu.towerDefense_Button.onClick.AddListener(() => Event_OnButton_Menu("towerDefense_Button"));
		GUI_Menu.exit_Button.onClick.AddListener(() => Event_OnButton_Menu("exit_Button"));

	}

	protected static void OnButtonPressed(string id, string desc, EventHandler<ButtonPressedEventArgs> handler){
		ButtonPressedEventArgs args = new ButtonPressedEventArgs();
		args.id = id;
		args.description = desc;

		if(handler != null){
			handler(GUI_Controller.instance, args);
		}
	}

	protected static void OnTogglePressed(string id, string desc, bool value, EventHandler<TogglePressedEventArgs> handler){
		TogglePressedEventArgs args = new TogglePressedEventArgs();
		args.id = id;
		args.description = desc;

		args.value = value;

		if(handler != null){
			handler(GUI_Controller.instance, args);
		}
	}
	public static void RemoveAllEvents(){
		GUI_Controller.GUI_Menu_ButtonPressed = null;
	}

	#endregion

	#region CALLBACKS
	void Event_OnButton_Menu(string id){
		switch(id){
			case "towerDefense_Button" : //MENU - TOWERDEFENSE
				OnButtonPressed(id, "MENU - BUTTON TOWERDEFENSE",GUI_Menu_ButtonPressed);
				break;
			case "exit_Button" : //MENU - EXIT
				OnButtonPressed(id, "MENU - BUTTON EXIT",GUI_Menu_ButtonPressed);
				break;
			default: break;
		}
	}

	#endregion

	#region UNITY_CALLBACKS
	protected override void Awake(){
		base.Awake();

		if (!this)
			return;

		FindGameObjects();

		InitializeClasses();
		InitializeListeners();
	}

//	void Update(){
//		
//		}

//	void OnGUI(){
//		
//		}
	#endregion

	#region COMMENTS
//	void OnButton_Menu(object sender, ButtonPressedEventArgs e){
//		switch(e.id){
//			case "towerDefense_Button" : //MENU - TOWERDEFENSE
//				Debug.Log(e.id + " - MENU - BUTTON TOWERDEFENSE");

//				break;
//			case "exit_Button" : //MENU - EXIT
//				Debug.Log(e.id + " - MENU - BUTTON EXIT");

//				break;
//			default: break;
//		}
//	}

//	void AssignEvents(){
//		GUI_Controller.RemoveAllEvents();

//		GUI_Controller.GUI_Menu_ButtonPressed += OnButton_Menu;

//	}
	#endregion
}
