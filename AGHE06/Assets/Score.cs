using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public float score;
	public bool showScore;
	public Diction diction;
	void Awake() {
		var scor = GameObject.FindObjectsOfType<Score>();
		if(scor.Length> 1) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad( this.gameObject);
		diction = new Diction();
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
