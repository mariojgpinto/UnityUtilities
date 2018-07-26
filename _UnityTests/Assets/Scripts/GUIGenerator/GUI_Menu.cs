using UnityEngine;
using System;
using System.IO;
using System.Collections;

using MPAssets;

public class GUI_Menu : MonoBehaviour {
	// MENU ---------------------------------------------
	public static GameObject				panel_gameObject;
	public static UnityEngine.UI.Image		panel;


	// TOWERDEFENSE ---------------------------------------------
	public static GameObject				towerDefense_Button_gameObject;
	public static UnityEngine.UI.Button		towerDefense_Button;

	public static GameObject				towerDefense_label_Text_gameObject;
	public static UnityEngine.UI.Text		towerDefense_label_Text;

	// EXIT ---------------------------------------------
	public static GameObject				exit_Button_gameObject;
	public static UnityEngine.UI.Button		exit_Button;

	public static GameObject				exit_label_Text_gameObject;
	public static UnityEngine.UI.Text		exit_label_Text;



	public static void UpdateValues(GameObject _panel){
		panel_gameObject = _panel.gameObject;
		panel = panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		towerDefense_Button_gameObject = panel_gameObject.transform.Find("Button_TowerDefense").gameObject;
		towerDefense_Button = towerDefense_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		towerDefense_label_Text_gameObject = towerDefense_Button_gameObject.transform.Find("Text_Label").gameObject;
		towerDefense_label_Text = towerDefense_label_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		exit_Button_gameObject = panel_gameObject.transform.Find("Button_Exit").gameObject;
		exit_Button = exit_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		exit_label_Text_gameObject = exit_Button_gameObject.transform.Find("Text_Label").gameObject;
		exit_label_Text = exit_label_Text_gameObject.GetComponent<UnityEngine.UI.Text>();
	}
}
