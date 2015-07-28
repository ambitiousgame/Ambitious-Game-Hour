using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
	public Text text;
	public PlayField playfield;
	// Use this for initialization
	void Start () {
		playfield = FindObjectOfType<PlayField>();
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = playfield.score.ToString();
	}
}
