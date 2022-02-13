using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escalera : MonoBehaviour {

	public GameObject player;
	CharacterController ct;
	public float upStearsSpeed = 2.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerStay(Collider colider){
		player.GetComponent<FPSController>().setGravity(10);
		player.GetComponent<FPSController>().setGrounded(true);
		if (colider.tag.Equals ("Player") && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))) {
			player.transform.Translate (Vector3.up * Time.deltaTime* upStearsSpeed, Space.World);
		}
	}
	private void OnTriggerExit(Collider colider){
		player.GetComponent<FPSController>().setGravity(20.0f);
		player.GetComponent<FPSController>().setGrounded(false);
	}

}
