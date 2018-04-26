using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

//GameInfo holds static variables about the game state that can be called from any scene
public class GameInfo {
	static public int playerCount = 2; //number of players currently playing the game
	static public Dictionary<string, string> inputMap = new Dictionary<string, string>(8)
	{
		{"PlayerOne", "PlayerOne"},
		{"PlayerTwo", "PlayerTwo"},
		{"PlayerThree", "PlayerThree"},
		{"PlayerFour", "PlayerFour"},
		{"PlayerFive", "PlayerFive"},
		{"PlayerSix", "PlayerSix"},
		{"PlayerSeven", "PlayerSeven"},
		{"PlayerEight", "PlayerEight"},
	};
}
