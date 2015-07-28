using UnityEngine;
using System.Collections;

public class Flying : MonoBehaviour {
	public float speed;
	public float min;
	public float max;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var x = this.transform.position.x + speed* Time.deltaTime;
		if (x < min) {
			x = min;
			speed = -1 * speed;
		}
		if (x > max) {
			x = max;
			speed = -1 * speed;
		}
		this.transform.position = new Vector3(x,transform.position.y,transform.position.z);
	}
}
