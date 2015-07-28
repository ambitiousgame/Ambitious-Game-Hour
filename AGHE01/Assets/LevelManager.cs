using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public GameObject Person;
	public GameObject Floor;
	public float DistanceToNewGeneration;
	public float DistanceAhead;
	public float scaleMin;
	public float scaleMax;
	public float yMin;
	public float yMax;
	public float minYChange;
	private float sinceLastGeneration;
	private float lastY;
	// Use this for initialization
	void Start () {
		Person = GameObject.FindGameObjectWithTag("Player");
		sinceLastGeneration = Person.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if(Person.transform.position.x - sinceLastGeneration > DistanceToNewGeneration) {
			var newFloor = (GameObject)Instantiate(Floor, new Vector3(NewX(), NewY(), 0),Quaternion.identity);
			sinceLastGeneration = Person.transform.position.x;
			lastY = newFloor.transform.position.y;
		}
	}

	private float NewY() {
		return Random.Range(lastY-minYChange < yMin ? yMin : lastY-minYChange, lastY+minYChange > yMax ? yMax : lastY+minYChange);
	}
	private float NewX() {
		return Person.transform.position.x + DistanceToNewGeneration + DistanceAhead;
	}
}
