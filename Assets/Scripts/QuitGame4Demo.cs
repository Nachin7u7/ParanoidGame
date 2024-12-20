using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame4Demo : MonoBehaviour
{

	private void OnTriggerEnter (Collider other)
	{
		if (other.tag.Equals ("Player"))
			Application.Quit();
	}
}
