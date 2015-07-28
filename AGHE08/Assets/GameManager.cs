using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager gameManager;
	public GameObject canvas;
	public bool menu;
	public int loadLevel;
	public Rect screen;
	public float speedMulti = 1;
	void Awake() {
		if(FindObjectsOfType<GameManager>().Length > 1) {
			Destroy(this.gameObject);
		}
		gameManager = this;
		if( menu) {
			Time.timeScale = 0;
			canvas.SetActive(true);
		} else {
			canvas.SetActive(false);
		}
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		speedMulti += Time.deltaTime * .2f;
	}
	public void GameOver() {
		Debug.Log("Game Over");
		Time.timeScale = 0;
		canvas.SetActive(true);
	}
	public void StartGame() {
		Time.timeScale = 1;
		canvas.SetActive(false);
		Application.LoadLevel(loadLevel);
	}
}
