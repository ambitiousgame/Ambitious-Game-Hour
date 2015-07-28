using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public Vector2 InitVel;
	public float speed;
	public float AddToSpeed;
	private Rigidbody2D phys;
	private float addedSpeed;
	public PlayField playfield;
	// Use this for initialization
	void Start () {
		playfield = FindObjectOfType<PlayField>();
		phys = this.gameObject.GetComponent<Rigidbody2D>();
		phys.AddForce(InitVel);
		Debug.Log("starting");
		addedSpeed = 1;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			if (coll.contacts.Length > 0) {
				Debug.Log("contact");
				phys.AddForce((coll.contacts[0].point -new Vector2(0,0)).normalized * (speed*addedSpeed));
				
				addedSpeed += AddToSpeed;
				playfield.score++;
			} 
		}
	}
}
