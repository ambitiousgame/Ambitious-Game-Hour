﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Diction {
	public HashSet<string> words;
	public Diction() {
		var wordSplit = wordString.Split(" "[0]);
		words = new HashSet< string >(wordSplit);
	}
	public bool isWord(string word) {
		return words.Contains(word);
	}
}