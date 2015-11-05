using UnityEngine;
using System.Collections;

public class Swipe : MonoBehaviour {
	Vector2[] positions;
	Vector2[] delta_positions;

	int finger_count;

	public static int swipe;
	
	// Use this for initialization
	void Start () {
		delta_positions = new Vector2[10];
		positions = new Vector2[10];
	}
	
	// Update is called once per frame
	void Update () {
		finger_count = 0;

		foreach (UnityEngine.Touch touch in Input.touches) {
			delta_positions[finger_count] = touch.deltaPosition;
			positions[finger_count] = touch.position;

			finger_count++;
		}
	}

	void OnGUI(){
		GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
		myButtonStyle.fontSize = 30;
		
		// Load and set Font
		Font myFont = (Font)Resources.Load("Fonts/comic", typeof(Font));
		myButtonStyle.font = myFont;

		if(finger_count > 0){
			if(delta_positions[0].x > 10){
				GUI.Button(new Rect(50, 550, 200,200), "RIGHT", myButtonStyle);
				swipe = 1;
			} else
			if(delta_positions[0].x < -10){
				GUI.Button(new Rect(50, 550, 200,200), "LEFT", myButtonStyle);
				swipe = 2;
			} 
			else{
				GUI.Button(new Rect(50, 550, 200,200), "NONE", myButtonStyle);
				swipe = 0;
			}
		}else{
			GUI.Button(new Rect(50, 550, 200,200), "NONE", myButtonStyle);
			swipe = 0;
		}
	}
}
