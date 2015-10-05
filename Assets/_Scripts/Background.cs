///////////////////////////////////////////////////////////////////////////////
// Files:			Background.cs
//
// Author:			Sangbeom Yi
// Description:		Manage the Background
//
// Revision History 09/21/2015 file created
//					
//
// Last Modified by	09/21/2015


using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour
{
	// PUBLIC VAL. INSTANCE
	public float speed = 0.1f;

	// Update is called once per frame
	void Update ()
	{
		float y = Mathf.Repeat (Time.time * speed, 1);
		Vector2 offset = new Vector2 (0, y);
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
}