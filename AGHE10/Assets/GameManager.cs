using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GridObject[][] grid;
	public GameObject enemy;
	public GameObject player;
	public GridObject playerGrid;
	public Vector2 playerStart;
	public Vector2 topleft;
	public Vector2 distance;
	public float TimeBetweenTurns;
	private float since;
	private int numObjects = 0;
	public GridObject[] gridObjects;
	void Awake () {
		var gameManagers = FindObjectsOfType<GameManager>();
		if (gameManagers.Length > 1 ) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}
	// Use this for initialization
	void Start () {
		var realPlayer = (GameObject)Instantiate(player,GetLocation(playerStart),Quaternion.identity);
		playerGrid = realPlayer.GetComponent<GridObject>();
		gridObjects = new GridObject[25];
		playerGrid.SetLocation(playerStart,GetLocation(playerStart));
		grid = new GridObject[5][];

		for( int i = 0; i < 5; i ++ ) {
			grid[i] = new GridObject[5];
		}
		grid[(int)playerStart.x][(int)playerStart.y] = playerGrid;
	}

	Vector3 GetLocation(Vector2 gridLoc) {
		return new Vector3(topleft.x + gridLoc.x * distance.x,topleft.y + gridLoc.y * distance.y,0);
	}
	// Update is called once per frame
	void Update () {
		bool turn = false;
		since += Time.deltaTime;
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			var locaiton = playerGrid.location;
			if (locaiton.x > 0 ) {
				locaiton.x  = locaiton.x -1;
				playerGrid.SetLocation(locaiton,GetLocation(locaiton));
				newTurn(-1,0);
			}
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow)) {
			var locaiton = playerGrid.location;
			if (locaiton.x < 4 ) {
				locaiton.x  = locaiton.x +1;
				playerGrid.SetLocation(locaiton,GetLocation(locaiton));
				newTurn(1,0);
			}
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow)) {
			var locaiton = playerGrid.location;
			if (locaiton.y < 4 ) {
				locaiton.y  = locaiton.y +1;
				playerGrid.SetLocation(locaiton,GetLocation(locaiton));
				newTurn(0,1);
			}
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			var locaiton = playerGrid.location;
			if (locaiton.y > 0 ) {
				locaiton.y  = locaiton.y -1;
				playerGrid.SetLocation(locaiton,GetLocation(locaiton));
				newTurn(0,-1);
			}
		}
	}
	void newTurn(int x, int y) {
		bool gameover= false;
		var gridLoc = new Vector2(Random.Range(0,4),Random.Range(0,4));
		if (x < 0) {
			gridLoc.x = 0;
			gameover = CheckForGameOverX(0);
		} else if (x > 0 ) {
			gameover = CheckForGameOverX(4);
			gridLoc.x = 4;
		} else if (y < 0) {
			gameover = CheckForGameOverY(0);
			gridLoc.y = 0;
		} else if (y > 0 ) {
			gridLoc.y = 4;
			gameover = CheckForGameOverY(4);
		}
		
		for(int i = 0; i < 5;i++) {
			for(int j = 0; j < 5;j++) {
				if(grid[i][j] != null && grid[i][j] != playerGrid) {
					Debug.Log(string.Format("{0} {1} {2} {3}",gridLoc.x,gridLoc.y, i,j));
					var locaiton = grid[i][j].location;
					locaiton.y  = locaiton.y +y;
					locaiton.x = locaiton.x +x;
					if (locaiton.y >=0 && locaiton.x >= 0 && locaiton.x < 5 && locaiton.y < 5) {
						grid[i][j].SetLocation(locaiton,GetLocation(locaiton));
					}
				}
			}
		}
		if (true){//!gameover && grid[(int)gridLoc.x][(int)gridLoc.y] == null) {
			var realPlayer = (GameObject)Instantiate(enemy,GetLocation(gridLoc),Quaternion.identity);
			var gridObject = realPlayer.GetComponent<GridObject>();
			gridObject.SetLocation(gridLoc,GetLocation(gridLoc));
			grid[(int)gridLoc.x][(int)gridLoc.y] = gridObject;
		} else if(!gameover) {
			newTurn(x,y);
		}
	}
	bool CheckForGameOverX(int x) {
		for (int i = 0; i < 5;i++) {
			if(grid[x][i] == null) {
				return false;
			}
		}
		Debug.Log("GameOver");
		Time.timeScale = 0;
		return true;
	}
	bool CheckForGameOverY(int y) {
		for (int i = 0; i < 5;i++) {
			if(grid[i][y] == null) {
				return false;
			}
		}
		Debug.Log("GameOver");
		Time.timeScale = 0;
		return true;

	}
}
