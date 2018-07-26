using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float hitForce = 1;
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
		}
		catch (System.Exception) { /*ignore*/ }

		Destroy(this.gameObject);
	}
}
