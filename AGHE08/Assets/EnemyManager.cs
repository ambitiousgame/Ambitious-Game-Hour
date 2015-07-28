using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
	public GameObject[] enemy;
	public float time;
	private float since;

	// Use this for initialization
	void Start () {
		AddEnemy();
	}
	
	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate() {
		since += Time.fixedDeltaTime;
		if (since > time) {
			AddEnemy();
			since = 0;
		}
	}
	void AddEnemy() {
		var index = Random.Range(0,enemy.Length-1);
		Instantiate(enemy[index]);
	}
}
