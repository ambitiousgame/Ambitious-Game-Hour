using UnityEngine;
using System.Collections;

public class Data : MonoBehaviour {
	public static string title = "Shameful Bedtime Family";
	public static string information = "";
	public GameStates GameState {get; private set;}
	public GameStates StartState;
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
		GameState = StartState;
	}
	public void Start() {
		SetMenu();
	}
	public void Update() {		
		if (Input.GetKeyDown(KeyCode.Escape)) {
			SetGameState(GameStates.Paused);
		}
	}
	public void SetMenu() {
		switch(GameState) {
		case GameStates.MainMenu:
			StopGame();
			break;
		case GameStates.Paused:
			StopGame();
			break;
		case GameStates.Running:
			StartGame();
			break;
		case GameStates.GameOverLoss:
			StopGame();
			break;
		case GameStates.GameOverWin:
			StopGame();
			break;
		}
	}
	public void StartGame() {
		Time.timeScale = 1;
	}
	public void StopGame() {
		Application.LoadLevel(0);
	}
	public void RestartGame() {
		Time.timeScale = 1;
		Application.LoadLevel(0);
	}
	public void SetGameState(GameStates newState) {
		Debug.Log("Setting GameState :" + newState.ToString());
		if (newState == GameStates.GameOverLoss) {
			RestartGame();
		}
	}
}
