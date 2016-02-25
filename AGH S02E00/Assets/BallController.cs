using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
    private GameManager game;
    private Rect posit;
	// Use this for initialization
	void Start () {
        posit = new Rect(this.transform.position.x, this.transform.position.y, .1f, 1f);
        game = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        posit.x = this.transform.position.x;
        posit.y = this.transform.position.y;
	    if(!game.ScreenBounds.Overlaps(posit)) {
            game.BallDone();
            Destroy(gameObject);
        }
	}
}
