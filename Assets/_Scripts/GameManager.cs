///////////////////////////////////////////////////////////////////////////////
// Files:			GameManager.cs
//
// Author:			Sangbeom Yi
// Description:		GameManager
//
// Revision History 10/01/2015 file created
//					10/02/2015 add title object
//
// Last Modified by	10/04/2015

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	// PUBLIC VAL. INSTANCE
	public GameObject player;
	// PRIVATE VAL. INSTANCE
	private GameObject title;
	private bool bGameOver = false;

	// Use this for initialization
	void Start () {
		title = GameObject.Find ("Title");
	}

	// Update is called once per frame
	void Update () {
		// Check the Mouse L Button.
		//Input.GetButton("Fire1")
		if (IsPlaying () == false && Input.GetKeyDown("z")) {//Input.GetButton("Fire1")) {
			GameStart ();
		}
	}
	
	void GameStart () {
		bGameOver = false;
		title.SetActive (false);
		Instantiate (player, player.transform.position, player.transform.rotation);
	}

	// Game Over
	public void GameOver () {
		FindObjectOfType<Score>().Save();
		// Title show up, when game is over.
		title.SetActive (true);
		bGameOver = true;
	}

	// It is for checking title font.
	public bool IsPlaying () {
		return title.activeSelf == false;
	}

	// Check the game over status.
	public bool IsGameOver() {
		return bGameOver;
	}
}