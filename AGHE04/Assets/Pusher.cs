using UnityEngine;
using System.Collections;

public class Pusher : MonoBehaviour {
	public Vector2 push;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Player")) {
			Debug.Log("entered1");
			other.gameObject.GetComponent<Rigidbody2D>().AddForce(push);
		}
	}
	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.CompareTag("Player")) {
			Debug.Log("entered");
			other.gameObject.GetComponent<Rigidbody2D>().AddForce(push);
		}
	}
}
