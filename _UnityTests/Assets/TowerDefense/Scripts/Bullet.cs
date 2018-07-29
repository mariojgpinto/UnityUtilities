using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	#region VARIABLES
	public float hitForce = 2;

	#endregion

	#region UNITY_CALLBACKS
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (this.transform.position.magnitude >20)
			Destroy(this.gameObject);
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		try {
			collision.gameObject.GetComponent<Enemy>().Hit(hitForce);
			Destroy(this.gameObject);
		}
		catch (System.Exception) { /*ignore*/ }
	}
	#endregion
}
