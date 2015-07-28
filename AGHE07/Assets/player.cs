using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public float speed;
	public Sprite ColorChange;
	public GameColors gameColor;
	private bool moving;
	private Rigidbody2D rigid;
	private SpriteRenderer spriter;
	// Use this for initialization
	void Start () {
		rigid = this.GetComponent<Rigidbody2D>();
		spriter = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(rigid.velocity.x == 0 && rigid.velocity.y == 0 && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)) {
			var horizontal = Input.GetAxis("Horizontal") ;
			var vertical = Input.GetAxis("Vertical"); 
			if (Mathf.Abs(horizontal) > Mathf.Abs(vertical)) {
				Debug.Log(" horizontal" +(speed * horizontal > 0 ? 1 : -1));
				rigid.AddForce(new Vector2( speed * horizontal > 0 ? 1 : -1,0),ForceMode2D.Impulse); 
			} else {
				Debug.Log(" vertical" +(speed * horizontal > 0 ? 1 : -1));
				rigid.AddForce(new Vector2(0,speed * vertical > 0 ? 1 : -1),ForceMode2D.Impulse); 
			}
		}
	}

	void FixedUpdate() {

	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("ColorChange")) {
			var colo = other.GetComponent<ColorChanger>();
			spriter.sprite = colo.CharacterColor;
			ColorChange = colo.NewColor;
			gameColor = colo.gameColor;
		}
		if (other.CompareTag("PieceChanged") && ColorChange != null) {
			var piece = other.GetComponent<SpriteRenderer>();
			var piecee = other.GetComponent<Piece>();
			piece.sprite = ColorChange;
			GameManager.gameManager.ColorChange(gameColor,piecee.gameColor); 
			piecee.gameColor = gameColor;
		}
	}
}
