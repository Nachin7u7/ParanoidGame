﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otroDeMoverObjetos : MonoBehaviour {

	public GameObject musica;
	public GameObject sonidoRoto;
	public GameObject player;
	public GameObject nuevoPunto;
	AudioSource sonido;
	bool aux;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other){
		
		if (musica != null || player != null || nuevoPunto != null || sonidoRoto != null) {
			sonido = musica.GetComponent<AudioSource> ();
			aux = sonido.mute;

			if (player.tag.Equals ("Player") && aux) {
				player.transform.position = new Vector3 (player.transform.position.x,
					player.transform.position.y,
					nuevoPunto.transform.position.z);

				GameObject sound = Instantiate (sonidoRoto);
				sound.transform.position = new Vector3 (player.transform.position.x,
					player.transform.position.y,
					player.transform.position.z);

			}
		}
	}

}
