﻿using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Projectile")) {
			FindObjectOfType<GameManager>().addScore();
			Destroy(this.gameObject);
		}
	}
}
