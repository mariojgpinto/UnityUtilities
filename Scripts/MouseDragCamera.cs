using UnityEngine;
using System.Collections;

public class MouseDragCamera : MonoBehaviour {
	#region VARIABLES
	private Vector3 lastMousePosition;
	private bool active;
	#endregion
	
	#region ACCESS_PROPERTIES
	public bool Active
	{
		set
		{
			this.active = value;
		}
	}
	#endregion
	
	#region UNITY_METHODS
	void Start () 
	{
		this.active = true;
	}
	
	void Update () 
	{
		if(this.active)
		{
			if(Input.GetMouseButton(0))
			{
				if(Input.GetMouseButtonDown(0))
				{
					lastMousePosition = Input.mousePosition;	
				}
				else
				{
					this.transform.RotateAround(Vector3.zero, new Vector3(0, 1, 0), (Input.mousePosition.x - lastMousePosition.x) / 5);
				}
				
				lastMousePosition = Input.mousePosition;
			}
		}
	}
	#endregion
}
