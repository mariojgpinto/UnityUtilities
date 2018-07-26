using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
	public GameObject prefab_Target;
	public GameObject targets_parent;

	public GameObject enemy_parent;
	public GameObject prefab_Enemy;

	public Text text_TouchCount;

	const int MAX_TARGETS = 4;
	List<GameObject> targets = new List<GameObject>();

	public static bool debug = true;


	void SpawnEnemy() {
		GameObject go = Instantiate(prefab_Enemy, enemy_parent.transform, false);
		go.transform.position = new Vector3(
			Random.Range(0, 2) > 0 ? -15 : 15,
			Random.Range(-5f, 5f),
			0);
		if (go.transform.position.x < 0) {
			Vector3 scale = go.transform.localScale;
			scale.y *= -1;
			go.transform.localScale = scale;
		}
	}

	// Use this for initialization
	void Start () {
		for(int i = 0; i < MAX_TARGETS; ++i) {
			targets.Add(Instantiate(prefab_Target, targets_parent.transform, false));
		}

		InvokeRepeating("SpawnEnemy", 1, 2);
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < MAX_TARGETS ; ++i) {
			if(i < Input.touchCount) {
				targets[i].SetActive(true);
				targets[i].transform.position = Input.touches[i].position;
			}
			else
				targets[i].SetActive(false);
		}

		if (debug) {
			text_TouchCount.text = "Touches: " + Input.touchCount;
		}
	}
}
