using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogos : MonoBehaviour {
	
	public GameObject texto;
	public float x=0,y=0,z=0;
	public float time = 4.0f;
	bool canAppear = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float time2=0;
		time2 += Time.deltaTime;
		if (time2 > time && canAppear) {
			canAppear = false;
			GameObject teex = Instantiate (texto);
			teex.transform.position = new Vector3 (this.gameObject.transform.position.x + x,
				this.gameObject.transform.position.y + y,
				this.gameObject.transform.position.z + z);
			teex.transform.SetParent (this.transform);
			//Destroy (GameObject.Find (TextInicialPrefab.name + "(Clone)"));
		}
		
	}
}
