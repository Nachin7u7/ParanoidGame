using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextLevel : MonoBehaviour {

	public GameObject player;
	public string nivel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter (Collider colider)	{
		if (player.tag.Equals ("Player")) {
			Application.LoadLevel (nivel);
		}	
	}
}