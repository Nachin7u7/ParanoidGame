using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeText : MonoBehaviour
{
	public RectTransform textTransform;
	// Asigna el RectTransform del texto desde el editor
	public float shakeIntensity = 5f;
	// Intensidad del movimiento
	public float shakeSpeed = 20f;
	// Velocidad del movimiento

	private Vector3 originalPosition;

	void Start ()
	{
		// Guarda la posición original del texto
		if (textTransform == null) {
			textTransform = GetComponent<RectTransform> ();
		}

		originalPosition = textTransform.localPosition;
	}

	void Update ()
	{
		// Genera un movimiento frenético usando valores aleatorios
		float offsetX = (Mathf.PerlinNoise (Time.time * shakeSpeed, 0f) * 2f - 1f) * shakeIntensity;
		float offsetY = (Mathf.PerlinNoise (0f, Time.time * shakeSpeed) * 2f - 1f) * shakeIntensity;

		// Aplica el movimiento al texto
		textTransform.localPosition = originalPosition + new Vector3 (offsetX, offsetY, 0f);
	}

	void OnDisable ()
	{
		// Asegúrate de restaurar la posición original si el texto se desactiva
		textTransform.localPosition = originalPosition;
	}
}
