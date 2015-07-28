using UnityEngine;
using System.Collections;

public class PlayField : MonoBehaviour {
	public Game game;
	public int score;
	void Awake() {
		DontDestroyOnLoad(this);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D(Collider2D collider) {
		if(collider.tag == "Ball") {
			game = FindObjectOfType<Game>();
			game.GameOver();
		}
	}
}
