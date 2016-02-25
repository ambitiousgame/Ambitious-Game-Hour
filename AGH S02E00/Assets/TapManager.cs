using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class TapManager : MonoBehaviour {
    public GameObject tap;
    public float force;
    private Vector3 start;
    public bool sent = false;
    private bool started = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(!sent && Input.GetMouseButtonDown(0)) {
            var v3 = Input.mousePosition;
            v3.z = 10.0f;
            start = Camera.main.ScreenToWorldPoint(v3);
            started = true;
        }
        if(started && Input.GetMouseButtonUp(0)) {
            var end = Input.mousePosition;
            end.z = 10.0f;
            end = Camera.main.ScreenToWorldPoint(end);
            var circle = (GameObject)Instantiate(tap, start, Quaternion.identity);
            var forceVector = new Vector2(end.x - start.x, end.y - start.y);
            circle.GetComponent<Rigidbody2D>().AddForce(forceVector.normalized * force);
            Debug.DrawRay(start,end,Color.red);
            Debug.Log(start.ToString() + end.ToString());
            sent = true;
        }


	}
}
