using UnityEngine;
using System.Collections;

public class DeleteAfter : MonoBehaviour {
	public float deleteAfter;
	private float since= 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		since += Time.deltaTime;
		if(since > deleteAfter) {
			Destroy(this.gameObject);
		}
	}
}
