using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {
	int fingerCount = 0;

	Vector2[] positions;
	public GameObject[] balls;

	// Use this for initialization

	void Start () {
		positions = new Vector2[10];
		balls = new GameObject[10];

		//ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		//ball.transform.position = new Vector3(0,0,-3);

		for(int i = 0 ; i < 10 ; ++i){
			balls[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			balls[i].transform.position = new Vector3(i, 0 ,-5);
		}
	}
	
	// Update is called once per frame
	void Update () {
		fingerCount = 0;

		foreach (UnityEngine.Touch touch in Input.touches) {
			positions[fingerCount] = touch.position;
			
			Vector3 pos = camera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y,5));
			
			balls[fingerCount].transform.position = pos;//camera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,5));
			
			fingerCount++;

//			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled){
//
//				positions[fingerCount] = touch.position;
//
//				Vector3 pos = camera.ScreenToWorldPoint(new Vector3(touch.rawPosition.x, touch.rawPosition.y,5));
//
//				balls[fingerCount].transform.position = pos;//camera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,5));
//
//				fingerCount++;
//			}
		}

//		if(Input.GetMouseButton(0)){
//			Debug.Log("MousePos: " + Input.mousePosition + "     CameraTransform:" + camera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,5)));
//
//			//ball.transform.position = camera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,5));
//			balls[0].transform.position = camera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,5));
//
//		}
	}



	void OnGUI() {
		//Input.touches[0]
		//if (fingerCount > 0){

		GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
		myButtonStyle.fontSize = 30;
		
		// Load and set Font
		Font myFont = (Font)Resources.Load("Fonts/comic", typeof(Font));
		myButtonStyle.font = myFont;

		GUI.Button(new Rect(50,50,300,450), "N:" + fingerCount + 
		           						    "\nB0: " + balls[0].transform.position + 
								            "\nB1: " + balls[1].transform.position + 
								            "\nB2: " + balls[2].transform.position + 
								            "\nB3: " + balls[3].transform.position + 
								            "\nB4: " + balls[4].transform.position + 
								            "\nB5: " + balls[5].transform.position + 
								            "\nB6: " + balls[6].transform.position + 
								            "\nB7: " + balls[7].transform.position + 
								            "\nB8: " + balls[8].transform.position + 
		           							"\nB9: " + balls[9].transform.position ,myButtonStyle
								           );


//		for(int i = 0 ; i < fingerCount ; ++i){
//			GUI.Button(new Rect(positions[i].x-20,Screen.height - (positions[i].y -20),20,20), "x" );
//		}
		//}

		if(GUI.Button(new Rect(Screen.width-150, Screen.height-150,100,100), "Switch", myButtonStyle)){
			Application.LoadLevel(1);
		}
	}
}
