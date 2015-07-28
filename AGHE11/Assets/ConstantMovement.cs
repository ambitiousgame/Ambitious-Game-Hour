using UnityEngine;
using System.Collections;

public class ConstantMovement : MonoBehaviour {
	public Vector2 Force;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(this.transform.position.x + Force.x,
		                                      this.transform.position.y + Force.y,
		                                      this.transform.position.z );
	}
}
