using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mostrarTexto : MonoBehaviour {
	[Header("Ajustes de posición")]
	public float x=-0.1f,y=0.3f,z=-0.3f;

	public GameObject texto;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	GameObject ob;

	private void OnTriggerEnter(Collider colider){

		if(colider.tag.Equals("Player")){
			ob = Instantiate (texto);
			ob.transform.position = new Vector3(this.gameObject.transform.position.x+x, 
				this.gameObject.transform.position.y+y, 
				this.gameObject.transform.position.z+z );
		}	
	}
	private void OnTriggerExit(Collider colider){
		Destroy (ob.gameObject);
	}
}
