using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByeFrank : MonoBehaviour
{

	public GameObject frank;
	public AudioSource sound;
	public ParticleSystem particles;

	public void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			frank.gameObject.SetActive (false);
			sound.Play ();
			sound.loop = true;
			particles.Play ();
			this.GetComponent<Collider> ().enabled = false;
		}
	}
}
