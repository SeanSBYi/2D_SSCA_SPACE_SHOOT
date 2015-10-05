///////////////////////////////////////////////////////////////////////////////
// Files:			DestroyArea.cs
//
// Author:			Sangbeom Yi
// Description:		Manage Available Field
//
// Revision History 09/28/2015 file created
//					
// Last Modified by	09/28/2015


using UnityEngine;
using System.Collections;

public class DestroyArea : MonoBehaviour {
	void OnTriggerExit2D (Collider2D c) {
		Destroy (c.gameObject);
	}
}