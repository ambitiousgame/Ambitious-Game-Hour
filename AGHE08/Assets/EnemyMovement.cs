using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	public Vector2 movement;
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x < GameManager.gameManager.screen.x) {
			Destroy(this.gameObject);
		}
		else if (this.transform.position.x > GameManager.gameManager.screen.x +GameManager.gameManager.screen.width) {
			Destroy(this.gameObject);
		}
		else if (this.transform.position.y < GameManager.gameManager.screen.y) {
			Destroy(this.gameObject);
		}
		else if (this.transform.position.y > GameManager.gameManager.screen.y+GameManager.gameManager.screen.height) {
			Destroy(this.gameObject);
		}
	}

	void FixedUpdate() {
		var newspot = speed * Time.fixedDeltaTime * movement * GameManager.gameManager.speedMulti;
		newspot.x += this.transform.position.x;
		newspot.y += this.transform.position.y;
		this.transform.position = newspot;
	}
}
