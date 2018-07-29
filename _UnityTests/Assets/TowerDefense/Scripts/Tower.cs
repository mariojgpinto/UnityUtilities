using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
	public Camera cmr;

	public GameObject prefab_bullet;
	public GameObject bulletsParent;

	Vector3 screenPosition;

	int currentTouch = 0;

	// Use this for initialization
	void Start () {
		

		InvokeRepeating("Fire", .5f, .5f);
	}
	
	void Fire() {
		if (Input.touchCount > 0) {
			GameObject bullet = Instantiate(prefab_bullet, bulletsParent.transform, false);
			bullet.transform.position = this.transform.position;
			Vector3 dir = (Vector3)Input.touches[currentTouch].position - screenPosition;
			bullet.GetComponent<Rigidbody2D>().AddForce(dir.normalized *.1f);
		}

#if UNITY_EDITOR
		if (Input.GetMouseButton(0)) {
			GameObject bullet = Instantiate(prefab_bullet, bulletsParent.transform, false);
			bullet.transform.position = this.transform.position;
			Vector3 dir = Input.mousePosition - screenPosition;
			bullet.GetComponent<Rigidbody2D>().AddForce(dir.normalized * .1f);
		}
#endif
	}
	// Update is called once per frame
	void Update () {
		if(Input.touchCount > 0) {
			screenPosition = cmr.WorldToScreenPoint(this.transform.position);
			currentTouch = 0;
			float mins = 1000000;

			for (int i = 0; i < Input.touchCount; ++i) {
				float dist = (screenPosition - (Vector3)Input.touches[i].position).magnitude;
				if (dist < mins) {
					mins = dist;
					currentTouch = i;
				}
			}


			Vector3 dir = screenPosition - (Vector3)Input.touches[currentTouch].position;

			float angle = Mathf.Rad2Deg * Mathf.Atan2(dir.y, dir.x);
			this.transform.rotation = Quaternion.Euler(0,0, angle);
		}
#if UNITY_EDITOR
		if (Input.GetMouseButton(0)) {
			screenPosition = cmr.WorldToScreenPoint(this.transform.position);
			currentTouch = 0;
			float mins = 1000000;
			
				float dist = (screenPosition - Input.mousePosition).magnitude;
				if (dist < mins) {
					mins = dist;
				}


			Vector3 dir = screenPosition - Input.mousePosition;

			float angle = Mathf.Rad2Deg * Mathf.Atan2(dir.y, dir.x);
			this.transform.rotation = Quaternion.Euler(0, 0, angle);
		}
#endif
	}
}
