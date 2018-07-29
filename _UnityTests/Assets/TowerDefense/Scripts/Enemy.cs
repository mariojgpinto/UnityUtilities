using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public static class EnemyFactory {
	public static void CreateEnemy(ref Enemy enemy) {
		int rnd = Random.Range(0, 100);

		if(rnd < 5) {
			CreateBlack(ref enemy);
		} else
		if (rnd < 15) {
			CreateWhite(ref enemy);
		} else
		if (rnd < 30) {
			CreateRed(ref enemy);
		} else
		if (rnd < 55) {
			CreateBlue(ref enemy);
		} else { 
			CreateGreen(ref enemy);
		}
	}

	static void CreateGreen(ref Enemy enemy) {
		enemy.speed = 2;
		enemy.life = 2;
		enemy.color = Color.green;

		enemy.Initialize();
	}

	static void CreateBlue(ref Enemy enemy) {
		enemy.speed = 1.8f;
		enemy.life = 4;
		enemy.color = Color.blue;

		enemy.Initialize();
	}

	static void CreateRed(ref Enemy enemy) {
		enemy.speed = 1.5f;
		enemy.life = 8;
		enemy.color = Color.red;

		enemy.Initialize();
	}

	static void CreateWhite(ref Enemy enemy) {
		enemy.speed = 4;
		enemy.life = 1;
		enemy.color = Color.white;

		enemy.Initialize();
	}

	static void CreateBlack(ref Enemy enemy) {
		enemy.speed = 1;
		enemy.life = 12;
		enemy.color = Color.black;

		enemy.Initialize();
	}
}

public class Enemy : MonoBehaviour {
	#region VARIABLES
	public float speed = 2f;
	public float life = 1;
	public float currentLife = 1;
	public Color color;

	bool isVisible = false;
	bool isAlive = true;

	List<GameObject> wreckage = new List<GameObject>();
	#endregion

	public void Initialize() {
		currentLife = life;
		this.GetComponent<SpriteRenderer>().color = color;

		for (int i = 0; i < 4; ++i) {
			wreckage.Add(this.transform.GetChild(i).gameObject);
		}
		for (int i = 0; i < 4; ++i) {
			wreckage[i].GetComponent<SpriteRenderer>().color = color;
			wreckage[i].SetActive(false);
		}
	}

	public void Hit(float hitForce) {
		if (!isVisible)
			return;

		currentLife -= hitForce;
		Color clr = this.GetComponent<SpriteRenderer>().color;
		if (currentLife <= 0) {
			StartCoroutine(DestroySelf());
		}
		else {
			clr.a = 1 - ((life - currentLife) / life) * 0.5f;
		}
		this.GetComponent<SpriteRenderer>().color = clr;
	}

	IEnumerator DestroySelf() {
		isAlive = false;
		this.GetComponent<SpriteRenderer>().enabled = false;
		this.GetComponent<BoxCollider2D>().enabled = false;

		for (int i = 0; i < 4; ++i) {
			wreckage[i].SetActive(true);
			wreckage[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1,1), Random.Range(-1, 1)) * 10);
		}

		Color clr = wreckage[0].GetComponent<SpriteRenderer>().color;
		for (int t = 0; t < 10; t++) {
			clr.a = (1 - 0.1f * t) * 0.5f;
			for (int i = 0; i < 4; ++i) {
				wreckage[i].GetComponent<SpriteRenderer>().color = clr;
			}
			yield return new WaitForSeconds(0.1f);
		}
		Destroy(this.gameObject);
	}
	#region UNITY_CALLBACKS
	// Use this for initialization
	void Start () {
		currentLife = life;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!isAlive)
			return;

		Vector3 pos = this.transform.position;

		this.transform.position = pos + pos.normalized * Time.deltaTime * -speed;

		float angle = Mathf.Rad2Deg * Mathf.Atan2(pos.normalized.y, pos.normalized.x);// Vector3.SignedAngle(screenPosition, (Vector3)Input.touches[0].position, Vector3.up);
																//Debug.Log("Dir: " + dir + " | | Angle: " + angle);
		this.transform.rotation = Quaternion.Euler(0, 0, angle);

		if (Input.GetKeyDown(KeyCode.H))
			Hit(2);
	}

	private void OnBecameVisible() {
		isVisible = true;
	}
	#endregion
}
