using UnityEngine;
using System.Collections;

public class MoveTowards : MonoBehaviour {
	public Vector3 MoveTo;
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Vector3.MoveTowards(this.transform.position,MoveTo,speed*Time.deltaTime);
	}
}
