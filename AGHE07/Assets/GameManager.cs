using UnityEngine;
using System.Collections;

public enum GameColors {
	Red = 0,Blue = 1, None =2
}
public class GameManager : MonoBehaviour {

	public static GameManager gameManager;
	public int[] numColored;
	public int numBlocks;
	public int nextLevel;
	void Awake() {
		var others = GameObject.FindObjectsOfType<GameManager>();
		if (others.Length > 1) {
			Destroy(this.gameObject);
		}
		gameManager = this;
		numColored = new int[3];
		Time.timeScale = 0;

	}
	// Use this for initialization
	void Start () {
		numColored[(int)GameColors.None] = numBlocks;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Win() {
		Application.LoadLevel(nextLevel);
	}

	public void ColorChange(GameColors color, GameColors prev) {
		Debug.Log("color change" + color + prev);
		numColored[(int)color]++;
		numColored[(int)prev]--;
		if (numColored[(int)color] == numBlocks) {
			Win ();
		}
	}

	public void Reset( int numRed, int numBlue, int max, int extLevel) {
		numColored[(int)GameColors.Red] = numRed;
		numColored[(int)GameColors.Blue] = numBlue;
		numColored[(int)GameColors.None] = max;
		numBlocks = max + numRed+ numBlue;
		nextLevel = extLevel;
		Time.timeScale = 0;
	}
}
