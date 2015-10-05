//////////////////////////////////////////////////////////////////////////////
// Files:			Score.cs
//
// Author:			Sangbeom Yi
// Description:		Manage Score Board
//
// Revision History 09/28/2015 file created
//					10/01/2015 add show score
//					10/02/2015 add save high score
//
// Last Modified by	10/05/2015
using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
	// PUBLIC INSTANCE VAL.
	public GUIText scoreGUIText;
	public GUIText highScoreGUIText;
	
	// PRIVATE INSTANCE VAL.
	private int score;
	private int highScore;
	private string highScoreKey = "highScore";

	// Use this for initialization
	void Start () {
		Initialize ();
	}

	// Update is called once per frame
	void Update () {
		// Update HighScore Point
		if (highScore < score) {
			highScore = score;
		}

		scoreGUIText.text = score.ToString ();
		highScoreGUIText.text = "HighScore : " + highScore.ToString ();
	}
	
	// Initialize game.
	private void Initialize (){
		score = 0;
		highScore = PlayerPrefs.GetInt (highScoreKey, 0);
	}
	
	// Add Point
	public void AddPoint (int point){
		score = score + point;
	}
	
	// Save the Highscore
	public void Save () {
		// Save the HighscorePoint
		PlayerPrefs.SetInt (highScoreKey, highScore);
		PlayerPrefs.Save ();
		
		// Reset the Game
		Initialize ();
	}
}