using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public float score;
	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		score += Time.deltaTime * 100;
	}

	void OnGUI() {
		GUI.Label(new Rect(10, 10, 100, 20),score.ToString());
		//GUI.Label(new Rect(0,0,100,100),"score: "+Score);
		
	}
}
