using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {
	public Vector3 center = new Vector3(0,0,0);
	public float speed;
	private Vector3 Axis = new Vector3(0,0,1);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Horizontal") != 0) { 
			this.transform.RotateAround(center,Axis,Input.GetAxis("Horizontal")*speed);
		}
	}
}
