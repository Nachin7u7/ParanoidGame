using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
	CharacterController ct;
	bool aux = false, aux2 = false;

	[Header ("Opciones de personaje")]
	public float walkSpeed = 6.0f;
	public float crouchedDown = 2.0f;
	public float runSpeed = 10.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;

	private Vector3 move = Vector3.zero;

	[Header ("Opciones de cámara")]
	public Camera cam;
	public float mouseHorizontal = 3f;
	public float mouseVertical = 3f;
	public float minRotation = -65f;
	public float maxRotation = 60f;

	float h_mouse, v_mouse;

	[Header ("Audio de Pasos")]
	public AudioSource footstepAudioSource;
	// AudioSource para el sonido de pasos
	public AudioClip footstepClip;
	// El archivo de audio de pasos
	public bool isWalking = false;

	public float runPitch = 1.5f;
	// Pitch al correr (más rápido)
	public float walkPitch = 1.0f;
	// Pitch al caminar (velocidad normal)

	void Start ()
	{
		ct = GetComponent<CharacterController> ();
		Cursor.lockState = CursorLockMode.Locked;

		// Configurar el AudioSource
		if (footstepAudioSource != null && footstepClip != null) {
			footstepAudioSource.clip = footstepClip;
			footstepAudioSource.loop = true; // Hacer que el audio se repita
		}
	}

	public void setGravity (float g)
	{
		gravity = g;
	}

	public void setGrounded (bool v)
	{
		aux2 = v;
	}

	void Update ()
	{
		Cursor.visible = false;
		aux = ct.isGrounded || aux2;

		h_mouse = mouseHorizontal * Input.GetAxis ("Mouse X");
		v_mouse += mouseVertical * Input.GetAxis ("Mouse Y");

		v_mouse = Mathf.Clamp (v_mouse, minRotation, maxRotation);
		cam.transform.localEulerAngles = new Vector3 (-v_mouse, 0, 0);
		transform.Rotate (0, h_mouse, 0);

		if (aux) {
			move = new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical"));
			if (Input.GetKey (KeyCode.LeftShift)) {
				move = transform.TransformDirection (move) * runSpeed;
				footstepAudioSource.pitch = runPitch;
			} else {
				move = transform.TransformDirection (move) * walkSpeed;
				footstepAudioSource.pitch = walkPitch;
			}
			if (Input.GetKey (KeyCode.Space)) {
				move.y = jumpSpeed;
			}

			// Control del sonido de pasos
			if (move.x != 0 || move.z != 0) { // Verificar si hay movimiento
				if (!isWalking) {
					footstepAudioSource.Play (); // Reproducir sonido si no está caminando
					isWalking = true;
				}
			} else {
				if (isWalking) {
					footstepAudioSource.Stop (); // Detener sonido si se detuvo
					isWalking = false;
				}
			}
		} else {
			if (isWalking) {
				footstepAudioSource.Stop (); // Detener sonido si no está en el suelo
				isWalking = false;
			}
		}

		move.y -= gravity * Time.deltaTime;
		ct.Move (move * Time.deltaTime);
	}
}
