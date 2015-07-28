using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	public Canvas canvas;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame() {
		var playfield = FindObjectOfType<PlayField>();
		if(playfield != null) {
			playfield.score = 0;
		}
		Application.LoadLevel(1);
	}
	public void GameOver() {
		Application.LoadLevel(2);
	}
}
