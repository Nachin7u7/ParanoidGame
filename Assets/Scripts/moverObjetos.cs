using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverObjetos : MonoBehaviour {

	public GameObject player;
	public GameObject objeto;
	public GameObject punto;
	[Header("Ajuste de punto")]
	public float x=0,y=0,z=0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider other){
		if (player.tag.Equals ("Player")) {
			objeto.transform.position = new Vector3 (punto.transform.position.x + x,
				punto.transform.position.y + y,
				punto.transform.position.z + z);
		}
	}
}
