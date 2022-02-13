using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutoCamara : MonoBehaviour {

	TextMesh texto;
	bool canChange = true;
	public float ajuste = 0.1f;
	public float ajuste2 = 0.1f;
	float time1 = 0;
	float time2 = 0;
	float time = 0;
	float timePorSiAcaso=0;
	int msj = 0;
	// Use this for initialization
	void Start () {
		texto = GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		timePorSiAcaso += Time.deltaTime;
		if (((msj == 0) || (msj == 1)) && (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow) ||
			Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow) ||
			Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow) ||
			Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow))) {
			texto.text = "Tutorial absurdo aludido exitosamente!";
				if(timePorSiAcaso > 3)
					Destroy (this.gameObject);
		}
		
		time1 += Time.deltaTime;
		if (time1 > 4 && msj == 0)
			texto.text = "Mueve el mouse para ver a los lados";
		if (Input.GetAxis ("Mouse Y") >= 2 || Input.GetAxis ("Mouse X") >= 2|| Input.GetAxis ("Mouse Y") <= -2 || Input.GetAxis ("Mouse X") <= -2) {
			if (canChange) {
				canChange = false;
				texto.text = "¡Bien!";
				msj++;
				time += Time.deltaTime;
			}
		}
		//time1  =0;
		if (msj == 1)
			time += Time.deltaTime;

		if (time > 2 && msj == 1) {
			texto.text = ("Ahora intenta caminar con A,S,D,W o\n") +
			(" las flechas del teclado");
			if ((Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow) ||
			    Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow) ||
			    Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow) ||
			    Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow))) {
				texto.text = "¡Bien hecho!";
				time2 += Time.deltaTime;
				msj++;
			}
		}
		if (msj == 2)
			time2 += Time.deltaTime;
		if(msj == 2 && time2 > 3){
			Destroy (this.gameObject);
		}
	}
}
