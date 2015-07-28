using UnityEngine;
using System.Collections;

public class Gameover : MonoBehaviour {
	public Data data;
	public GameObject Player;
	public float EndingHeight;
	// Use this for initialization
	void Start () {
		data = (Data)GameObject.FindObjectOfType(typeof(Data));
		Player = GameObject.FindGameObjectWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.transform.position.y < EndingHeight) {
			data.SetGameState(GameStates.GameOverLoss);
		}
	}
}
