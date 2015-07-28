using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public int currentX;
	public int currentY;
	public Rect places;
	public float timeBetweenMoves;
	public float distance;
	public Vector2 baseLoc;
	private float currentTimeX;
	private float currentTimeY;
	// Use this for initialization
	void Start () {
		currentTimeX = timeBetweenMoves;
		currentTimeY = timeBetweenMoves;
	}
	
	// Update is called once per frame
	void Update () {
		bool updated = false;
		currentTimeX += Time.deltaTime;
		currentTimeY += Time.deltaTime;
		if(Input.GetAxis("Horizontal") < 0 && currentTimeX > timeBetweenMoves) {
			if(currentX > 0) {
				currentX--;
				updated = true;
				currentTimeX = 0;
			}
		}
		if(Input.GetAxis("Horizontal") > 0 && currentTimeX > timeBetweenMoves) {
			if(currentX < places.width-1) {
				currentX++;
				updated = true;
				currentTimeX = 0;
			}
		}
		if(Input.GetAxis("Vertical") < 0 && currentTimeY > timeBetweenMoves) {
			if(currentY > 0) {
				currentY--;
				updated = true;
				currentTimeY = 0;
			}
		}
		if(Input.GetAxis("Vertical") > 0 && currentTimeY > timeBetweenMoves) {
			if(currentY < places.height-1) {
				currentY++;
				updated = true;
				currentTimeY = 0;
			}
		}
		if(updated) {
			UpdateLocation();
		}
	}
	void UpdateLocation() {
		this.transform.position = new Vector2(currentX*distance+baseLoc.x,currentY*distance+baseLoc.y);
	}
	void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Enemy") ){ 
			GameManager.gameManager.GameOver();
		}
	}

}
