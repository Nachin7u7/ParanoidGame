using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frankFlashing : MonoBehaviour
{
	public float minTime = 1f;
	// Tiempo mínimo entre apariciones
	public float maxTime = 5f;
	// Tiempo máximo entre apariciones
	public float visibleDuration = 0.5f;
	// Duración de la visibilidad

	private MeshRenderer meshRenderer;

	void Start ()
	{
		// Obtener el componente MeshRenderer del objeto
		meshRenderer = GetComponent<MeshRenderer> ();

		if (meshRenderer == null) {
			Debug.LogError ("El objeto no tiene un MeshRenderer. Asegúrate de que sea un objeto con un material asignado.");
			return;
		}

		// Asegurarse de que el plano sea invisible al inicio
		meshRenderer.enabled = false;

		// Iniciar la rutina de aparición/desaparición
		StartCoroutine (HandleVisibility ());
	}

	IEnumerator HandleVisibility ()
	{
		while (true) {
			// Esperar un tiempo aleatorio antes de aparecer
			float waitTime = Random.Range (minTime, maxTime);
			yield return new WaitForSeconds (waitTime);

			// Hacer visible el plano
			meshRenderer.enabled = true;

			// Mantenerlo visible por un tiempo definido
			yield return new WaitForSeconds (visibleDuration);

			// Hacer invisible el plano
			meshRenderer.enabled = false;
		}
	}
}
