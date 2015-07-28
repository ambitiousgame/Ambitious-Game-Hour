using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showscore : MonoBehaviour {
	
	public Text text;
	public Score score;
	// Use this for initialization
	void Start () {
		score = FindObjectOfType<Score>();
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(score.showScore) {
			text.text = string.Format("score:{0}",score.score);
		}
	}
}
