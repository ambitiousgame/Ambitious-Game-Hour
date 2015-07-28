using UnityEngine;
using System.Collections;

public class ResetLevel : MonoBehaviour {
	public int numRed;
	public int numBlue;
	public int max;
	public int nextlevel;
	// Use this for initialization
	void Start () {
		GameManager.gameManager.Reset(numRed,numBlue,max,nextlevel);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
