using System.Collections;
using UnityEngine;

public class BulbBalance : MonoBehaviour
{
	public Vector3 forceDirection;
	// Dirección de la fuerza
	public float amplitude = 5f;
	// Amplitud del movimiento (qué tan fuerte es el balanceo inicial)
	public float frequency = 1f;
	// Frecuencia del movimiento (qué tan rápido oscila)

	private Rigidbody bulbRigidbody;
	// Rigidbody del bombillo
	private float elapsedTime = 0f;
	// Tiempo acumulado para calcular el movimiento sinusoidal

	void Start ()
	{
		// Obtener el último hijo (el bombillo)
		if (transform.childCount > 0) {
			Transform lastChild = transform.GetChild (transform.childCount - 1);
			bulbRigidbody = lastChild.GetComponent<Rigidbody> ();
		} else {
			Debug.LogError ("El objeto no tiene hijos. Por favor, agrega un bombillo como hijo.");
		}
	}

	void FixedUpdate ()
	{
		if (bulbRigidbody != null) {
			// Incrementar el tiempo acumulado
			elapsedTime += Time.fixedDeltaTime;

			// Calcular la fuerza sinusoidal
			float oscillation = Mathf.Sin (elapsedTime * frequency) * amplitude;

			// Aplicar la fuerza en la dirección especificada
			Vector3 force = forceDirection.normalized * oscillation;
			bulbRigidbody.AddForce (force, ForceMode.Force);
		}
	}
}
