using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    private TapManager tap;
    public Rect ScreenBounds;
    public GameObject[] Levels;
    public int current;
    private GameObject currentLevel;
    private int collectables;
    // Use this for initialization
    void Start () {
        tap = FindObjectOfType<TapManager>();
        StartLevel();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void BallDone() {
        tap.sent = false;
        if(FindObjectsOfType<CollectController>().Length == 0) {
            NextLevel();
        } else {
            RestartLevel();
        }
    }

    public void StartLevel() {
        currentLevel = (GameObject)Instantiate(Levels[current]);
        collectables = FindObjectsOfType<CollectController>().Length;
        Debug.Log("Start level");
    }

    public void RestartLevel() {
        Debug.Log("Restart level");
        Destroy(currentLevel);
        StartLevel();
    }

    public void NextLevel() {
        Debug.Log("Next level");
        Destroy(currentLevel);
        current++;
        if (current < Levels.Length) {
            StartLevel();
        } else {
            Application.LoadLevel(0);
        }
    }
}
