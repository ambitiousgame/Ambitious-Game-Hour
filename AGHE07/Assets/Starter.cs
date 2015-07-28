using UnityEngine;
using System.Collections;

public class Starter : MonoBehaviour {
	public Canvas hide;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame() {
		hide.enabled = false;
		Time.timeScale = 1;
	}
}
