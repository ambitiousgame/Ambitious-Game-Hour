using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreText : MonoBehaviour {
	public Text text;
	public GameManager gameManager;
	void Awake() {
		text = this.GetComponent<Text>();
		gameManager = FindObjectOfType<GameManager>();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		text.text = gameManager.score.ToString();
	}
}
