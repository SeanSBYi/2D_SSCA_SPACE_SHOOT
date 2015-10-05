///////////////////////////////////////////////////////////////////////////////
// Files:			GameManager.cs
//
// Author:			Sangbeom Yi
// Description:		GameManager
//
// Revision History 09/18/2015 file created
//					09/21/2015 add player movement
//					09/23/2015 change player movement mouse->keyboard
//					09/25/2015 add player shot function
//					09/29/2015 check the player collider
//
// Last Modified by	10/04/2015

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	// PUBLIC INSTANCE VAL.
	public float fireRate = 0.0f;
	public int playerLife = 3;

	// PRIVATE INSTANCE VAL.
	private float nextFire;
	private AudioSource _shootAudioSource;

	// Player Based Component
	Spaceship spaceship;

	/*
	IEnumerator Start () {
		spaceship = GetComponent<Spaceship> ();
		
		while (true) {
			spaceship.Shot (transform);

			GetComponent<AudioSource>().Play();
			yield return new WaitForSeconds (spaceship.shotDelay);
		}
	}
	*/

	// Use this for initialization
	void Start() {
		spaceship = GetComponent<Spaceship> ();
		this._shootAudioSource = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		Vector2 direction = _CheckInput ();
		Move (direction);

		// Check a press key.
		if (Input.GetKey("z") && Time.time > nextFire){
			nextFire = Time.time + fireRate;
			spaceship.Shot (transform);
			this._shootAudioSource.Play ();
		}
	}

	// Input.
	private Vector2 _CheckInput() {
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");
		return new Vector2 (x, y).normalized;
	}

	// Manage the Player Movement in Update()
	private void Move (Vector2 direction) {
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
		Vector2 pos = transform.position;

		pos += direction  * spaceship.speed * Time.deltaTime;
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);

		transform.position = pos;

		/*
		// movement by mouse
		Vector2 mousePosition = Input.mousePosition;
		this._newPosition.x = this.camera.ScreenToWorldPoint(mousePosition).x;//mousePosition.x;
		*/
	}
	
	// Check the Collider
	void OnTriggerEnter2D (Collider2D c) {
		string layerName = LayerMask.LayerToName(c.gameObject.layer);

		// Crash enemy bullet and enemy ship
		if( layerName == "Bullet (Enemy)") {
			Destroy(c.gameObject);
		}

		if( layerName == "Bullet (Enemy)" || layerName == "Enemy"){
			Destroy(c.gameObject);
			this.playerLife--;

			// For Display Player Life
			int localPlayerLife = this.playerLife % 3;
			if( localPlayerLife == 2) {
				GameObject.FindWithTag("Star01").SetActive(false);
			}
			if( localPlayerLife == 1) {
				GameObject.FindWithTag("Star02").SetActive(false);
			}

			spaceship.Explosion();


			if( playerLife <= 0 ) {
				FindObjectOfType<GameManager>().GameOver();
				Destroy (gameObject);
			}
		}
	}
}