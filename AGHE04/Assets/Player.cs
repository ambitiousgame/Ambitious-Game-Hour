using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Level level;
	private Rigidbody2D body;
	public bool move;
	public bool ended;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		move = true;
		ended = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(move && Input.GetAxis("Horizontal") != 0 ) {
			var x =transform.position.x +  Input.GetAxis("Horizontal");
			if (x < -10) {
				x = -10;
			}
			if (x > 10) {
				x = 10;
			}
			transform.position = new Vector3(x,transform.position.y,transform.position.z);
		}
		if (move && Input.GetButton("Jump")) {
			body.gravityScale = 1;
			move = false;
		}
		if (!ended && !move && transform.position.y < -6) {
			level.EndLevel(false);
			ended = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Goal")) {
			level.EndLevel(true);
		}
		if(other.CompareTag("Killer")) {
			level.EndLevel(false);
		}
	}
}
