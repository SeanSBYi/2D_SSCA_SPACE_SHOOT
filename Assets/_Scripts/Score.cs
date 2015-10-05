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
	
	void Start ()
	{
		Initialize ();
	}
	
	void Update ()
	{
		// Update HighScore Point
		if (highScore < score) {
			highScore = score;
		}

		scoreGUIText.text = score.ToString ();
		highScoreGUIText.text = "HighScore : " + highScore.ToString ();
	}
	
	// Initialize game.
	private void Initialize ()
	{
		score = 0;
		highScore = PlayerPrefs.GetInt (highScoreKey, 0);
	}
	
	// Add Point
	public void AddPoint (int point)
	{
		score = score + point;
	}
	
	// Save the Highscore
	public void Save ()
	{
		// Save the HighscorePoint
		PlayerPrefs.SetInt (highScoreKey, highScore);
		PlayerPrefs.Save ();
		
		// Reset the Game
		Initialize ();
	}
}