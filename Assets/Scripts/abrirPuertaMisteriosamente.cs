using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPuertaMisteriosamente : MonoBehaviour {


	public GameObject player;
	public GameObject puerta;
	public GameObject sonido;
	bool closed = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other){
		if (player.tag.Equals ("Player") && closed) {
			closed = false;
			puerta.transform.Rotate (0, 90, 0);
			GameObject sonidoDePuerta = Instantiate (sonido);
			sonidoDePuerta.transform.position = new Vector3 (puerta.transform.position.x,
				puerta.transform.position.y,
				puerta.transform.position.z);
		}
	}
}
