using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Timer : MonoBehaviour {
	public Text text;
	public float time;
	private float timeFloat;
	private GameController game;
	// Use this for initialization
	void Start () {
		timeFloat = time;
		game = FindObjectOfType<GameController>();
	}
	// Update is called once per frame
	void Update () {
		timeFloat = timeFloat - Time.deltaTime;
		if(timeFloat <= 0) {
			timeFloat = 0;
			game.EndGame();
		}
		text.text = timeFloat.ToString();
	}
}
