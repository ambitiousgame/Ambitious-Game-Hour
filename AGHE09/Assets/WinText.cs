using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinText : MonoBehaviour {
	private Text text;
	private GameManager game;
	// Use this for initialization
	void Start () {
		text = this.GetComponent<Text>();
		game = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = game.winString;
	}
}
