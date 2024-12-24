using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextLevel : MonoBehaviour
{
	public string level;

	private void OnTriggerEnter (Collider collider)
	{
		if (collider.tag.Equals ("Player"))
			Application.LoadLevel (level);
		
	}
}