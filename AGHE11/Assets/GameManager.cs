using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject Enemy;
	public float radius;
	public float chance;
	public float chancePower;
	public float addedChance;
	public float speed;
	public float score;
	public GameObject unHide;
	public GameObject unHide2;
	private float initialSpeed;
	public GameObject Power;
	private float powerups = 1;
	// Use this for initialization
	void Start () {
		unHide.SetActive(false);
		unHide2.SetActive(false);
		initialSpeed = chance;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Random.value < chance+addedChance && Time.timeScale > 0) {
			var randAngle = Random.Range(0f,2*Mathf.PI);
			var rand = new Vector3(Mathf.Cos(randAngle) * radius,
			                       Mathf.Sin(randAngle) * radius,
			                       0);
			Debug.Log(rand);
			var obj = (GameObject)Instantiate(Enemy,rand, Quaternion.identity);
			obj.GetComponent<MoveTowards>().speed *=powerups;
			addedChance += speed;
		}
		if (Random.value < chancePower+addedChance && Time.timeScale > 0) {
			var randAngle = Random.Range(0f,2*Mathf.PI);
			var rand = new Vector3(Mathf.Cos(randAngle) * radius,
			                       Mathf.Sin(randAngle) * radius,
			                       0);
			Debug.Log(rand);
			Instantiate(Power,rand, Quaternion.identity);
			addedChance += speed;
		}
	}
	public void addScore() {
		score += 1;
	}
	public void GameOver() {
		Debug.Log("game over");
		Time.timeScale = 0;
		unHide.SetActive(true);
		unHide2.SetActive(true);
	}
	public void PowerUp() {
		foreach(var enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
			score += 1;
			Destroy(enemy);
		}
		foreach(var enemy in GameObject.FindGameObjectsWithTag("PowerUp")) {
			score += 1;
			Destroy(enemy);
		}
		score += 50;
		//speed = speed +speed;
		addedChance = 0;
		powerups++;
	}
	public void ReStart() {
		Application.LoadLevel(0);
	}
}
