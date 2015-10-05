///////////////////////////////////////////////////////////////////////////////
// Files:			BaseObject.cs
//
// Author:			Sangbeom Yi
// Description:		Character Object Share Module
//
// Revision History 10/02/2015 file created
//
// Last Modified by	10/04/2015

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour {
	// PUBLIC INSTANCE VAL.
	public float speed;
	public float shotDelay;
	public GameObject bullet;
	public bool canShot;
	public GameObject explosion;

	// Use this for initialization
	void Start (){
	}
	
	public void Explosion (){
		Instantiate (explosion, transform.position, transform.rotation);
	}

	public void Shot (Transform origin) {
		Instantiate (bullet, origin.position, origin.rotation);
	}
}