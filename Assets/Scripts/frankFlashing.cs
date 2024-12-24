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
	public GameObject frank;
	// El fantasma

	private MeshRenderer fankMesh, lightMesh;

	void Start ()
	{
		// Obtener el componente MeshRenderer del objeto fantasma
		fankMesh = frank.GetComponent<MeshRenderer> ();
		lightMesh = GetComponent<MeshRenderer> ();
		if (fankMesh == null) {
			Debug.LogError ("El objeto 'frank' no tiene un MeshRenderer. Asegúrate de que sea un objeto con un material asignado.");
			return;
		}

		// Asegurarse de que el fantasma sea invisible al inicio
		fankMesh.enabled = false;

		// Iniciar la rutina de aparición/desaparición
		StartCoroutine (HandleVisibility ());
	}

	IEnumerator HandleVisibility ()
	{
		while (true) {
			// Esperar un tiempo aleatorio antes de encender la luz
			float waitTime = Random.Range (minTime, maxTime);
			yield return new WaitForSeconds (waitTime);

			// Encender la luz
			lightMesh.enabled = true;

			// Determinar aleatoriamente si el fantasma aparecerá
			bool shouldFrankAppear = Random.value > 0.2f; // 50% de probabilidad

			if (shouldFrankAppear) {
				// Hacer visible al fantasma
				fankMesh.enabled = true;
			}

			// Mantener la luz encendida por un tiempo definido
			yield return new WaitForSeconds (visibleDuration);

			// Apagar la luz
			lightMesh.enabled = !true;

			// Hacer invisible al fantasma
			fankMesh.enabled = false;
		}
	}
}
