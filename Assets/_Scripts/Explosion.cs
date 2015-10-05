///////////////////////////////////////////////////////////////////////////////
// Files:			Explosion.cs
//
// Author:			Sangbeom Yi
// Description:		For Enemy Die Animation.
//
// Revision History 10/05/2015 file created
//					10/05/2015 Manage the Explosion Animation.
//					
// Last Modified by	10/02/2015

using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
	void OnAnimationFinish () {
		Destroy (gameObject);
	}
}