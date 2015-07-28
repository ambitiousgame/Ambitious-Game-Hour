using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public KeyCode left;
	public KeyCode right;
	public KeyCode fire;
	public KeyCode jump;
	public float speedX;
	public float maxSpeedX;
	public float speedY;
	public Rigidbody2D rigid;
	public GameObject fireObject;
	public float timeToFire;
	private float since;
	public int thisPlayer;
	public int otherPlayer;
	public string killingTag;
	// Use this for initialization
	void Start () {
		rigid = this.GetComponent<Rigidbody2D>();
		since = timeToFire;
	}
	
	// Update is called once per frame
	void Update () {
		var force = new Vector2();
		if (Input.GetKey(left)) {
			force.x -= speedX * Time.deltaTime;
		} 
		if (Input.GetKey(right)) {
			force.x += speedX * Time.deltaTime;
		} 
		if (Mathf.Abs(rigid.velocity.x) < maxSpeedX) {
			rigid.AddForce(force);
		}
		var isGrounded = Physics2D.Linecast(this.transform.position,new Vector3(this.transform.position.x,this.transform.position.y-1,this.transform.position.z)
		                                    , 1 << LayerMask.NameToLayer("Ground")); 
		if (Input.GetKeyDown (jump) && isGrounded == true)
		{
			Debug.Log("jump");
			//Add force to the players rigidbody allowing it to move upwards if the above if statement is true
			rigid.AddForce (Vector2.up * speedY);
		}
		since += Time.deltaTime;
		if (since > timeToFire && Input.GetKeyDown(fire)) {
			Instantiate(fireObject,this.transform.position,Quaternion.identity);
			since = 0;
		}

	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(killingTag)) {
			Debug.Log (string.Format(" player {0} lost and player {1} won",thisPlayer,otherPlayer));
			FindObjectOfType<GameManager>().EndGame(otherPlayer,thisPlayer);
		}
	}
}
