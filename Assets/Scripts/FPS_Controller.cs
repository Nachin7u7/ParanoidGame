using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Controller : MonoBehaviour
{
	CharacterController ct;
	bool aux = false, aux2 = false;

	[Header ("Opciones de personaje")]
	public float walkSpeed = 6.0f;
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
	// AudioSource para sonido de pasos
	public AudioClip footstepClip;
	// Clip de audio para pasos
	public float runPitch = 1.5f;
	// Pitch al correr (más rápido)
	public float walkPitch = 1.0f;
	// Pitch al caminar (velocidad normal)
	public bool isWalking = false;

	void Start ()
	{
		ct = GetComponent<CharacterController> ();
		Cursor.lockState = CursorLockMode.Locked;

		footstepAudioSource.Stop ();

		// Configurar el AudioSource
		if (footstepAudioSource != null && footstepClip != null) {
			footstepAudioSource.clip = footstepClip;
			footstepAudioSource.loop = true; // Configurar el audio en loop
		}
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
			if (move.magnitude > 0.1f) { // Si hay movimiento
				if (Input.GetKey (KeyCode.LeftShift)) { // Si el jugador está corriendo
					move = transform.TransformDirection (move) * runSpeed;
					footstepAudioSource.pitch = runPitch; // Aumentar la velocidad del sonido
				} else { // Si el jugador está caminando
					move = transform.TransformDirection (move) * walkSpeed;
					footstepAudioSource.pitch = walkPitch; // Velocidad normal del sonido
				}

				// Reproducir sonido de pasos si no está sonando
				if (!footstepAudioSource.isPlaying) {
					footstepAudioSource.Play ();
				}
			} else {
				// Detener el sonido si no hay movimiento
				if (footstepAudioSource.isPlaying) {
					footstepAudioSource.Stop ();
				}
			}

			if (Input.GetKey (KeyCode.Space)) { // Salto
				move.y = jumpSpeed;
				footstepAudioSource.Stop ();
			}
		} else {
			move.y -= gravity * Time.deltaTime;
		}

		ct.Move (move * Time.deltaTime);
	}
}