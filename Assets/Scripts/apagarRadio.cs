using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apagarRadio : MonoBehaviour
{
	[Header ("AJUSTE")]
	public float x = 0, y = 0, z = 0;
	public GameObject player;
	public GameObject musica;
	public GameObject mensaje;
	bool apagado = false;
	TextMesh texto;
	float time = 0;
	AudioSource sonido;
	bool canAppear = true;
	// Use this for initialization
	void Start ()
	{
		//texto = mensaje.GetComponent<TextMesh> ();
		sonido = musica.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public bool isApagado ()
	{
		return sonido.mute;
	}

	GameObject nuevoText;

	private void OnTriggerStay (Collider colider)
	{
		time += Time.deltaTime;
		if (player.tag.Equals ("Player")) {
			if (canAppear) {
				canAppear = false;
				nuevoText = Instantiate (mensaje);
				nuevoText.transform.position = new Vector3 (this.gameObject.transform.position.x + x,
					this.gameObject.transform.position.y + y,
					this.gameObject.transform.position.z + z);
				texto = nuevoText.GetComponent<TextMesh> ();
				if (apagado)
					texto.text = "Press \"E\" to turn on the music";
				else
					texto.text = "Press \"E\" to turn off the music";
			}
			if (Input.GetKey (KeyCode.E) && time > 0.5) {
				apagado = !apagado;
				sonido.mute = !sonido.mute;
				time = 0;
				if (apagado)
					texto.text = "Press \"E\" to turn on the music";
				else
					texto.text = "Press \"E\" to turn off the music";
			}
		}
	}

	private void OnTriggerExit (Collider colider)
	{
		if (player.tag.Equals ("Player")) {
			canAppear = true;
			Destroy (nuevoText.gameObject);
		}
	}
}
