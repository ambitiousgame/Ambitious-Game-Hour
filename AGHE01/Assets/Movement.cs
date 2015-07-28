using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed;
	public float jump;
	public Rigidbody2D body;
	private bool canJump = false;
	// Use this for initialization
	void Start () {
		body = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(this.transform.position.x + speed * Time.deltaTime, this.transform.position.y,this.transform.position.z);
		if (Input.GetButtonDown("Jump") && canJump) {
			Debug.Log("jump");
			body.AddForce(new Vector2(0,jump));
			canJump = false;
		}
	}
	void OnTriggerStay2D(Collider2D other) {
		Debug.Log("collide with " + other.tag);

		if(other.tag == "CanJump") {
			canJump = true;
		}
	}
	void OnTriggerExitr2D(Collider2D other) {
		Debug.Log("exit collide with " + other.tag);

		if(other.tag == "CanJump") {
			canJump = false;
		}
	}
}
