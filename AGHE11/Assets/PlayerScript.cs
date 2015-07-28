using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public GameManager game;
	public float speedTillNext;
	public GameObject projectile;
	private float sinceProj = 0;
	// Use this for initialization
	void Start () {
		game = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		sinceProj += Time.deltaTime;
		if (Input.GetMouseButton(0) && sinceProj > speedTillNext) {
			var proj = (GameObject)Instantiate(projectile,this.transform.position,Quaternion.identity);
			var constantMovement = (ConstantMovement)proj.GetComponent<ConstantMovement>();
			constantMovement.Force = Camera.main.ScreenToWorldPoint(Input.mousePosition).normalized;
			sinceProj = 0;
		}
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy"){
			game.GameOver();
		}
		if (coll.gameObject.tag == "PowerUp"){
			game.PowerUp();
		}
	}
}
