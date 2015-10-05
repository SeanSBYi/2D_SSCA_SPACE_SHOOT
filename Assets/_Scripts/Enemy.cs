///////////////////////////////////////////////////////////////////////////////
// Files:			Enemy.cs
//
// Author:			Sangbeom Yi
// Description:		Enemy Controller
//
// Revision History 09/18/2015 file created
//					09/22/2015 Enemy can shot.
//					
// Last Modified by	10/02/2015

using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	// PUBLIC VAL. INSTANCE
	public int hp = 1;
	public int point = 100;

	// Base Component
	Spaceship spaceship;

	IEnumerator Start () {
		spaceship = GetComponent<Spaceship> ();
		Move (transform.up * -1);

		if (spaceship.canShot == false) {
			yield break;
		}
			
		// Loop the Shoot if enemy is alive.
		while (true) {
			for (int i = 0; i < transform.childCount; i++) {
				
				Transform shotPosition = transform.GetChild (i);
				spaceship.Shot (shotPosition);
			}

			yield return new WaitForSeconds (spaceship.shotDelay);
		}
	}

	// Manage the Enemy Movement
	public void Move (Vector2 direction) {
		GetComponent<Rigidbody2D>().velocity = direction * spaceship.speed;
	}

	// Check the Collider2D
	void OnTriggerEnter2D (Collider2D c) {
		string layerName = LayerMask.LayerToName (c.gameObject.layer);

		if (layerName != "Bullet (Player)") {
			return;
		}

		Transform playerBulletTransform = c.transform.parent;
		Bullet bullet =  playerBulletTransform.GetComponent<Bullet>();
		hp = hp - bullet.power;

		// Bullet doens't have hp. So, bullet trigger the collider, destroy the object ASAP.
		Destroy(c.gameObject);

		// Check the Destroy HP, if Enemy HP is lower than 0, enemy will be die.
		if(hp <= 0 ) {
			// Add Score.
			FindObjectOfType<Score>().AddPoint(point);
			spaceship.Explosion ();
			Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		// If it is GameOver, Destroy All Game Object for next game.
		if (FindObjectOfType<GameManager> ().IsGameOver ()) {
			Destroy (gameObject);
		}
	}
}
