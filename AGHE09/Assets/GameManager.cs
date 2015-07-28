using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public string winString;
	void Awake() { 
		var gameManagers = GameObject.FindObjectsOfType<GameManager>();
		if (gameManagers.Length > 1 ) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void EndGame(int playerWin, int playerLost) {
		this.winString = string.Format("Player {0} has destroyed Player {1}.  You going to take that!!!",playerWin,playerLost);
		Application.LoadLevel(0);
	}

	public void startGame() {
		Application.LoadLevel(1);
	}
}
