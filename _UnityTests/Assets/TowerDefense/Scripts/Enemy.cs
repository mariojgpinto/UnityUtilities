using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	#region VARIABLES
	public float speed = 2f;
	bool isVisible = false;
	#endregion

	public void Hit(float hitForce) {
		if (!isVisible)
			return;

		Color clr = this.GetComponent<SpriteRenderer>().color;
		if (clr.a <= 0) {
			Destroy(this.gameObject);
		}
		else {
			clr.a = clr.a - 0.5f;
		}
		this.GetComponent<SpriteRenderer>().color = clr;
	}


	#region UNITY_CALLBACKS
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 pos = this.transform.position;

		this.transform.position = pos + pos.normalized * Time.deltaTime * -speed;

		float angle = Mathf.Rad2Deg * Mathf.Atan2(pos.normalized.y, pos.normalized.x);// Vector3.SignedAngle(screenPosition, (Vector3)Input.touches[0].position, Vector3.up);
																//Debug.Log("Dir: " + dir + " | | Angle: " + angle);
		this.transform.rotation = Quaternion.Euler(0, 0, angle);
	}

	private void OnBecameVisible() {
		isVisible = true;
	}
	#endregion
}
