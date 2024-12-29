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

	[Header ("Settings")]
	public Settings settings;
	public GameObject settingsScreen;

	[Header ("Audio de Pasos")]
	public AudioSource footstepAudioSource;

	public AudioSource landingAudioSource;
	public AudioClip footstepClip;
	public AudioClip landingClip;
	public float runPitch = 1.5f;
	public float walkPitch = 1.0f;
	public bool isWalking = false;

	public bool jumped = false;
	private bool isPaused = false;
	// Bandera para controlar el estado de pausa

	public void SetSensitivity ()
	{
		mouseHorizontal = settings.Sensitivity * 10;
		mouseVertical = settings.Sensitivity * 10;
	}

	void Start ()
	{
		ct = GetComponent<CharacterController> ();
		Cursor.lockState = CursorLockMode.Locked;
		footstepAudioSource.Stop ();

		if (footstepAudioSource != null && footstepClip != null) {
			footstepAudioSource.clip = footstepClip;
			footstepAudioSource.loop = true;
		}
		if (landingAudioSource != null && landingClip != null) {
			landingAudioSource.clip = landingClip;
		}
		Cursor.visible = false;
	}

	void Update ()
	{
		if (settingsScreen.activeSelf) {
			isPaused = true; // Si la pantalla de configuración está activa, pausa el juego
		} else {
			isPaused = false; // Si no está activa, reanuda el juego
		}

		// Detener las acciones del jugador si está en pausa
		if (isPaused) {
			return; // Salir de Update si el juego está en pausa
		}

		aux = ct.isGrounded || aux2;

		if (!settingsScreen.activeSelf) {
			h_mouse = mouseHorizontal * Input.GetAxis ("Mouse X");
			v_mouse += mouseVertical * Input.GetAxis ("Mouse Y");

			v_mouse = Mathf.Clamp (v_mouse, minRotation, maxRotation);
			cam.transform.localEulerAngles = new Vector3 (-v_mouse, 0, 0);
			transform.Rotate (0, h_mouse, 0);
		}

		if (aux) {
			move = new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical"));
			if (move.magnitude > 0.1f) {
				if (jumped && ct.isGrounded) {
					landingAudioSource.Play ();
					jumped = false;
				}
				if (Input.GetKey (KeyCode.LeftShift)) {
					move = transform.TransformDirection (move) * runSpeed;
					footstepAudioSource.pitch = runPitch;
				} else {
					move = transform.TransformDirection (move) * walkSpeed;
					footstepAudioSource.pitch = walkPitch;
				}

				if (!footstepAudioSource.isPlaying) {
					footstepAudioSource.Play ();
				}
			} else {
				if (footstepAudioSource.isPlaying) {
					footstepAudioSource.Stop ();
				}
			}

			if (Input.GetKey (KeyCode.Space)) {
				move.y = jumpSpeed;
				footstepAudioSource.Stop ();
				jumped = true;
			}

			if (Input.GetKey (KeyCode.Escape)) {
				bool wasSettingsScreenActive = settingsScreen.activeSelf;
				settingsScreen.SetActive (!settingsScreen.activeSelf);
				Cursor.visible = settingsScreen.activeSelf;

				if (settingsScreen.activeSelf) {
					Cursor.lockState = CursorLockMode.None;
				} else {
					Cursor.lockState = CursorLockMode.Locked;

					if (wasSettingsScreenActive) {
						SetSensitivity ();
					}
				}
			}
		} else {
			move.y -= gravity * Time.deltaTime;
		}

		ct.Move (move * Time.deltaTime);
	}
}