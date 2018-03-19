using UnityEngine;
using System.Collections;

public class MouseDragCamera : MonoBehaviour {
	public Transform target;

	Vector3 deltaPosition = Vector3.up;

	public float distance = 5.0f;
	public float xSpeed = 120.0f;
	public float ySpeed = 120.0f;

	public float yMinLimit = -20f;
	public float yMaxLimit = 80f;

	public float distanceMin = .5f;
	public float distanceMax = 15f;

	float x = 0.0f;
	float y = 0.0f;

	// Use this for initialization
	void Start() {
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
		
		if(target == null) {
			GameObject go = new GameObject();
			go.transform.position = Vector3.zero;
			target = go.transform;
		}
	}

	void LateUpdate() {
		if (target) {
			if (Input.GetMouseButton(0)) {
				x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
				y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

				y = ClampAngle(y, yMinLimit, yMaxLimit);	
			}

			if (Input.GetMouseButton(1)) {
				Debug.Log("Mouse Left " + Input.GetAxis("Mouse X") + " - " + Input.GetAxis("Mouse Y"));

				float deltaY = Input.GetAxis("Mouse Y");

				deltaPosition.y += deltaY * .02f;
			}

			distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

			Quaternion rotation = Quaternion.Euler(y, x, 0);


			Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
			Vector3 position = rotation * negDistance + (target.position + deltaPosition);

			transform.rotation = rotation;
			transform.position = position;
		}

	}

	public static float ClampAngle(float angle, float min, float max) {
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}
}


/*

using UnityEngine;
using System.Collections;

public class MouseDragCamera : MonoBehaviour {
	#region VARIABLES
	public GameObject target = null;
	public Vector3 targetPosition;
	
	private Vector3 lastMousePosition;
	private Vector3 lastMousePositionUp;
	
	public float minDist = .5f;
	public float maxDist = 4;
	public float moveSpeed = .02f;
	public float scrollSpeed = .1f;
	
	public bool restriction = true;
	#endregion
	
	public void SetTarget(GameObject t){
		target = t;
		
		Vector3 pos = this.transform.position;
		
		if(GameObject.Find("sala_module") != null){
			pos.y = 2;
		}
		else{
			pos.y = t.GetComponentInChildren<Renderer>().bounds.max.y + (t.GetComponentInChildren<Renderer>().bounds.center.y / 2f);
		}
		pos.x = t.GetComponentInChildren<Renderer>().bounds.center.x;
		this.transform.position = pos;
		
		targetPosition = t.GetComponentInChildren<Renderer>().bounds.center;// + Vector3.up * .5f;
		//		targetPosition.x = t.GetComponentInChildren<Renderer>().bounds.center.x;
		//targetPosition = t.transform.position + Vector3.up * .5f;
		
		this.transform.LookAt(targetPosition, Vector3.up);
	}
	
	#region UNITY_METHODS
	void Start () 	{
		if( target != null){
			SetTarget(target);
		}
		
		es = GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>();
	}
	
	
	UnityEngine.EventSystems.EventSystem es;
	bool[] startMouse  = new bool[] {false, false};
	float factor = 6;
	
	void Update () 
	{
		for(int i = 0 ; i < 2 ; ++i){
			if(Input.GetMouseButtonDown(i) && !es.IsPointerOverGameObject()){
				lastMousePosition = Input.mousePosition;
				startMouse[i] = true;
			}
			if(Input.GetMouseButtonUp(i)){
				startMouse[i] = false;
			}
		}
		
		if(startMouse[0] && Input.GetMouseButton(0))
		{
			this.transform.RotateAround(targetPosition, new Vector3(0, 1, 0), (Input.mousePosition.x - lastMousePosition.x) / factor);
			
			if(restriction){
				if(this.transform.rotation.eulerAngles.y > 90 && this.transform.rotation.eulerAngles.y < 150){
					this.transform.RotateAround(targetPosition, new Vector3(0, 1, 0), (lastMousePosition.x - Input.mousePosition.x) / factor);
				}
				
				if(this.transform.rotation.eulerAngles.y < 270 && this.transform.rotation.eulerAngles.y > 200){
					this.transform.RotateAround(targetPosition, new Vector3(0, 1, 0), (lastMousePosition.x - Input.mousePosition.x) / factor);
				}
			}
			
			//			if(this.transform.rotation.eulerAngles.y < 95 || this.transform.rotation.eulerAngles.y > 265){
			//				this.transform.RotateAround(targetPosition, new Vector3(0, 1, 0), (Input.mousePosition.x - lastMousePosition.x) / factor);
			//			}
			
			this.transform.RotateAround(targetPosition, new Vector3(1, 0, 0), -(Input.mousePosition.y - lastMousePosition.y) / factor);
			
			if(restriction){
				if(this.transform.position.y < 0.1){
					this.transform.RotateAround(targetPosition, new Vector3(1, 0, 0), -(lastMousePosition.y - Input.mousePosition.y) / factor);
				}
				
				if(this.transform.rotation.eulerAngles.x > 80 && this.transform.rotation.eulerAngles.x < 120  ){
					this.transform.RotateAround(targetPosition, new Vector3(1, 0, 0), -(lastMousePosition.y - Input.mousePosition.y) / factor);
				}
				
				if(this.transform.rotation.eulerAngles.y > 90 && this.transform.rotation.eulerAngles.y < 150){
					this.transform.RotateAround(targetPosition, new Vector3(1, 0, 0), -(lastMousePosition.y - Input.mousePosition.y) / factor);
				}
				
				if(this.transform.rotation.eulerAngles.y < 270 && this.transform.rotation.eulerAngles.y > 200){
					this.transform.RotateAround(targetPosition, new Vector3(1, 0, 0), -(lastMousePosition.y - Input.mousePosition.y) / factor);
				}
			}
			
			//			if(this.transform.rotation.eulerAngles.y > 100 && this.transform.rotation.eulerAngles.y < 120){
			//				Debug.Log("Rotation Lock");
			//				Vector3 pos = this.transform.rotation.eulerAngles;
			//				pos.y = 100;
			//				this.transform.rotation = Quaternion.Euler( pos );
			//			}
			this.transform.LookAt(targetPosition, Vector3.up);
			
			lastMousePosition = Input.mousePosition;
		}
		
		//
		if(startMouse[1] && Input.GetMouseButton(1)){
			if(lastMousePositionUp.y > Input.mousePosition.y){
				targetPosition = targetPosition + Vector3.up * moveSpeed;
				this.transform.position = this.transform.position + Vector3.up * moveSpeed; 
				
				this.transform.LookAt(targetPosition, Vector3.up);
			} else
			if(lastMousePositionUp.y < Input.mousePosition.y){
				targetPosition = targetPosition - Vector3.up * moveSpeed;
				this.transform.position = this.transform.position - Vector3.up * moveSpeed;
				this.transform.LookAt(targetPosition, Vector3.up);
			}
			
			lastMousePositionUp = Input.mousePosition;
		}
		
		if(!es.IsPointerOverGameObject() && Input.mouseScrollDelta.y != 0){
			if(Input.mouseScrollDelta.y > 0 && Vector3.Distance(targetPosition, this.transform.position) > minDist){
				this.transform.position = this.transform.position + (targetPosition - this.transform.position).normalized * scrollSpeed;
			} else
			if(Input.mouseScrollDelta.y < 0 ){//&& Vector3.Distance(targetPosition, this.transform.position) < maxDist){
				this.transform.position = this.transform.position - (targetPosition - this.transform.position).normalized * scrollSpeed;
			} 
		}
	}
	
	void OnGUI(){
		if(Input.GetKeyDown(KeyCode.L)){
			restriction = true;
		}
		if(Input.GetKeyDown(KeyCode.K)){
			restriction = false;
		}
	}
	
	#endregion
}


*/