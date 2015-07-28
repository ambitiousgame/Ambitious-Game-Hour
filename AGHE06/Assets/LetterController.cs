using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LetterController : MonoBehaviour {
	public Rect location;
	public Image image;
	public Color32 onColor;
	public Color offColor;
	public Text text;
	public char textChar;
	public GameController controller;
	private bool activated = false;
	public Sprite onSprite;
	public Sprite offSprite;
	public Diction diction;
	// Use this for initialization
	void Awake () {
		image = GetComponent<Image>();
		text = this.gameObject.GetComponentInChildren<Text>();
		diction = new Diction();
	}

	void Start() {
		controller = FindObjectOfType<GameController>();
		location = new Rect(this.transform.position.x-15, this.transform.position.y-15, 70,70);
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)) {
			location.x = image.rectTransform.position.x-35;
			location.y = image.rectTransform.position.y-35;
			if(location.Contains(Input.mousePosition) && !activated) {
				Debug.Log(string.Format("Location:{0} location:{1} {2}",location,image.rectTransform.position,image.rectTransform.lossyScale));
				Activate();
			}
		}
	}

	public void SetChar(char textt) {
		textChar = textt;
		text.text = textt.ToString();
	}
	public void Activate() {
		image.sprite = onSprite;
		//image.color = onColor;
		controller.Activated(textChar,this);
		activated = true;
	}
	public void Deactivate() {
		image.sprite = offSprite;
		//image.color = offColor;
		activated = false;
	}
	void OnMouseEnter() {
		Debug.Log("Mouse Entered");
	}
}
