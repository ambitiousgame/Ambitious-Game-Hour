using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Level : MonoBehaviour {
	public int currentLevel;
	public int nextLevel;
	public Button NextLevel;
	public Button Retry;
	public Canvas canvas;
	// Use this for initialization
	void Start () {
		NextLevel.onClick.AddListener(() => Application.LoadLevel(nextLevel));
		Retry.onClick.AddListener(() => Application.LoadLevel(Application.loadedLevel));
		canvas.enabled = false;
		NextLevel.enabled = false;
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void EndLevel(bool win) {
		Debug.Log(string.Format("Ended {0}",win));
		Time.timeScale = 0;
		if(win) {
			NextLevel.enabled = true;
		}
		canvas.enabled = true;
	}

}