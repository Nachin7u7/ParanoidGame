using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class presentacion : MonoBehaviour {

	public GameObject texto;
	public GameObject autor;
	public GameObject punto;
	public GameObject sonido;
	public string lvl = "lvl3";
	float time =0;
	public float x=0,y=0,z=0;
	bool firstAppear = true;
	bool canAppearSong = true,canAppearSong1 = true;

	GameObject tex;
	TextMesh texto1;
	GameObject aut;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Cursor.visible = false;
		time += Time.deltaTime;
		if (time > 3) {
			

			if (canAppearSong) {
				canAppearSong = false;
				GameObject sound = Instantiate (sonido);
			

			 	tex = Instantiate (texto);
				tex.transform.position = new Vector3(punto.transform.position.x + x,
					punto.transform.position.y + y,
					punto.transform.position.z + z);
				texto1 = tex.GetComponent<TextMesh>();
			}

			if (time > 4.98 && firstAppear) {
				//Destroy (tex);
				firstAppear = false;
				texto1.text = "Por";
				tex.transform.position = new Vector3(punto.transform.position.x + x-10,
					punto.transform.position.y + y,
					punto.transform.position.z + z+3);
			}

			if (time > 7.11 && canAppearSong1) {
				canAppearSong1 = false;
				aut = Instantiate (autor);
				aut.transform.position = new Vector3(punto.transform.position.x + x+-4,
					punto.transform.position.y + y,
					punto.transform.position.z + z-1);
			}
			if (time > 10.644) {
				Destroy (aut);
				Destroy (tex);
			}
			if (time > 25) {
				Application.LoadLevel (lvl);
			}
		}
	}
}
