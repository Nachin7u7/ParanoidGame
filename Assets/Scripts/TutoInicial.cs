using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoInicial : MonoBehaviour {
	[Header("Ajustes de mensaje")]
	public float tiempoDeVida = 10.0f;
	public float x=0,y=0,z=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float time = 0;
		time -= Time.deltaTime;
		if (time <= tiempoDeVida)
			Destroy (this.gameObject);
	}
}
