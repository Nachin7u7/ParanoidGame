using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour {

	CharacterController ct;
	bool aux=false,aux2=false;
	[Header("Opciones de personaje")]
	public float walkSpeed = 6.0f;
	public float crouchedDown = 2.0f;
	public float runSpeed = 10.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;

	private Vector3 move = Vector3.zero;
	[Header("Opciones de cámara")]
	public Camera cam;
	public float mouseHorizontal = 3f;
	public float mouseVertical = 3f;
	public float minRotation = -65f;
	public float maxRotation = 60f;

	float h_mouse, v_mouse;

	// Use this for initialization
	void Start () {
		ct = GetComponent<CharacterController> ();
		Cursor.lockState = CursorLockMode.Locked;
	}
	public void setGravity(float g){
		gravity = g;
	}
	public void setGrounded(bool v){
		aux2 = v;
	}
	// Update is called once per frame
	void Update () {
		Cursor.visible = false;
		aux = ct.isGrounded || aux2;

		h_mouse = mouseHorizontal * Input.GetAxis ("Mouse X");
		v_mouse += mouseVertical * Input.GetAxis ("Mouse Y");

		v_mouse = Mathf.Clamp (v_mouse, minRotation, maxRotation);
		cam.transform.localEulerAngles = new Vector3 (-v_mouse, 0, 0);
		transform.Rotate(0, h_mouse, 0);
		//AQU
		if (aux) {
			move = new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical"));
			if (Input.GetKey (KeyCode.LeftShift))
				move = transform.TransformDirection (move) * runSpeed;
			//TODO AGACHARSE : 
			//else if (Input.GetKey (KeyCode.LeftControl)) {
				//Camera.main = Camera.main.transform (Camera.main.gameObject.transform.position.x,
				//	Camera.main.gameObject.transform.position.y - 1,
				//	Camera.main.gameObject.transform.position.z);
				//move = transform.TransformDirection (move) * crouchedDown;
		//	}
		else
				move = transform.TransformDirection (move) * walkSpeed;

			if (Input.GetKey (KeyCode.Space)) {
				move.y = jumpSpeed;
			}
		}
		move.y -= gravity * Time.deltaTime;
		ct.Move (move * Time.deltaTime);
	}
}
