using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public LetterController[] Row1;
	public LetterController[] Row2;
	public LetterController[] Row3;
	public LetterController[] Row4;
	private LetterController[] activatedLetters;
	private char[] letters;
	private int currentActivated;
	public Text currentWord;
	public Text wordBlock;
	public Score score;
	public Diction diction;
	public HashSet<string> usedWords;
	// Use this for initialization
	void Start () {
		letters = new char[16];
		for(int i = 0; i < 5;i++) {
			letters[i] = GetRandomVowel();
		}
		for(int i = 5; i < 16;i++) {
			letters[i] = GetRandomChar();
		}
		activatedLetters = new LetterController[16];
		currentActivated = 0;
		shuffle();
		Row1[0].SetChar(letters[0]);
		Row1[1].SetChar(letters[1]);
		Row1[2].SetChar(letters[2]);
		Row1[3].SetChar(letters[3]);
		Row2[0].SetChar(letters[4]);
		Row2[1].SetChar(letters[5]);
		Row2[2].SetChar(letters[6]);
		Row2[3].SetChar(letters[7]);
		Row3[0].SetChar(letters[8]);
		Row3[1].SetChar(letters[9]);
		Row3[2].SetChar(letters[10]);
		Row3[3].SetChar(letters[11]);
		Row4[0].SetChar(letters[12]);
		Row4[1].SetChar(letters[13]);
		Row4[2].SetChar(letters[14]);
		Row4[3].SetChar(letters[15]);
		score = FindObjectOfType<Score>();
		score.showScore = true;
		diction = score.diction;
		usedWords = new HashSet<string>();
	}
	public void shuffle() {
		char swap;
		for(int i = 0; i < 40;i++) { 
			int swaps = Random.Range(0,16);
			int swaps2 = Random.Range(0,16);
			swap = letters[swaps];
			letters[swaps] = letters[swaps2];
			letters[swaps2] = swap;

		}
	}
	public char GetRandomChar() {
		return (char) (Random.Range(0,26) + (int)'a');
	}
	public char GetRandomVowel() {
		int ran =  Random.Range(0,5);
		if (ran == 0) {
			return 'a';
		} else if (ran == 0) {
			return 'e';
		} else if (ran == 0) {
			return 'i';
		} else if (ran == 0) {
			return 'o';
		} 
		return 'u';
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(0)) {
			Debug.Log("mouse up");
			Reset();
		}
	}

	public void Activated(char text, LetterController letter) {
		AddLetter(text);
		activatedLetters[currentActivated++] = letter;

	}
	public void AddLetter(char text) {
		currentWord.text = currentWord.text + text.ToString();
	}
	public void Reset() {
		AddWord(currentWord.text);
		currentWord.text = "";
		Debug.Log(currentActivated);
		for ( int i  = 0; i < currentActivated;i++) {
			activatedLetters[i].Deactivate();
		}
		currentActivated = 0;
	}

	public void AddWord(string word) {
		if (diction.isWord(word) && !usedWords.Contains(word)){
			Debug.Log("contains");
			wordBlock.text += string.Format("{0} {1}\n",word,word.Length);
			score.score+= word.Length;
			usedWords.Add(word);
		}else {
			Debug.Log("Does not");
		}
	}
	public void EndGame() {
		score.showScore = true;
		Application.LoadLevel(0);
	}
}
