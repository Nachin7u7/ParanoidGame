using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPuerta : MonoBehaviour {

	public GameObject player;
	public GameObject eje;
	public bool open = true,canOpen = true;
	public float angle = 90.0f;
	public float time = 2.0f; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(waiter());
	}
	IEnumerator waiter(){
		yield return new WaitForSecondsRealtime(4);
	}

	private void OnTriggerStay(Collider colider){

		time += Time.deltaTime;

		if (player.tag.Equals ("Player") && Input.GetKey (KeyCode.E) && !open && time > 0.5) {
			open = true;
			eje.transform.Rotate (0, angle*2, 0);
			time = 0;

		}else if (player.tag.Equals ("Player") && Input.GetKey (KeyCode.E) && open && time > 0.5) {
			open = false;
			eje.transform.Rotate (0, -angle*2, 0);
			time = 0;
		}
	}

}
