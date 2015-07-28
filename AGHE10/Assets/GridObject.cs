using UnityEngine;
using System.Collections;

public class GridObject : MonoBehaviour {
	public Vector2 location;
	public void SetLocation(Vector2 location, Vector3 newLocation) {
		this.location = location;
		this.transform.position = newLocation;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
