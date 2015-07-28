using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Clicker : MonoBehaviour {
	public float numberOfObjects;
	public float perSec;
	public Text Display;
	public Button button;
	public Clicker lossClick;
	public Clicker multiplier;
	public float numToLose;
	public float numToGain;
	// Use this for initialization
	void Start () {
		button.onClick.AddListener(() => { 
			if(lossClick.numberOfObjects >= numToLose) {
				float multi = 1;
				if(multiplier != null) {
					multi = multiplier.numberOfObjects;
				}
				AddValue(numToGain * multi); 
				lossClick.AddValue(-numToLose); 
			}
		});
	}
	
	// Update is called once per frame
	void Update () {
		numberOfObjects += perSec * Time.deltaTime;
		Display.text = numberOfObjects.ToString();
	}

	public void AddValue(float value) {
		numberOfObjects += value;
	}

}
