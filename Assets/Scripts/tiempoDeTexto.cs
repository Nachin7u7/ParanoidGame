using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiempoDeTexto : MonoBehaviour {
	public float tiempoDeVida=2.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		tiempoDeVida -= Time.deltaTime;
		if (tiempoDeVida <= 0)
			Destroy (this.gameObject);
	}
}
