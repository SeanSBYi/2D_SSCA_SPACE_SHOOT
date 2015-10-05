///////////////////////////////////////////////////////////////////////////////
// Files:			WaveManager.cs
//
// Author:			Sangbeom Yi
// Description:		Manage the game wave
//
// Revision History 10/02/2015 file created
//
// Last Modified by	10/04/2015

using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {
	// PRIVATE INSTACE VAL.
	public GameObject[] waves;
	private int currentWave;
	private GameManager manager;
	
	IEnumerator Start () {
		// If waves is nothing, it doen't make sense.
		if (waves.Length == 0) {
			yield break;
		}

		manager = FindObjectOfType<GameManager>();
		
		while (true) {
			// Waiting start game.
			while(manager.IsPlaying() == false) {
				yield return new WaitForEndOfFrame ();
			}

			GameObject go = (GameObject)Instantiate (waves [currentWave], transform.position, Quaternion.identity);
			go.transform.parent = transform;

			while (go.transform.childCount != 0) {
				yield return new WaitForEndOfFrame ();
			}

			Destroy (go);
			
			// Loop the game.
			if (waves.Length <= ++currentWave) {
				currentWave = 0;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (FindObjectOfType<GameManager> ().IsGameOver ()) {
			currentWave = 0;
		}
	}
}