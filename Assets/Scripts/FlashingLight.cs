using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLight : MonoBehaviour
{
	public float minTime = 2f;
	// Tiempo mínimo entre apagados
	public float maxTime = 6f;
	// Tiempo máximo entre apagados
	public int flickerCount = 3;
	// Número de parpadeos
	public float flickerDuration = 0.1f;
	// Duración de cada parpadeo

	private Light lightComponent;

	void Start ()
	{
		// Obtener el componente Light del objeto
		lightComponent = GetComponent<Light> ();

		if (lightComponent == null) {
			Debug.LogError ("El objeto no tiene un componente Light. Asegúrate de que sea un objeto con una luz asignada.");
			return;
		}

		// Iniciar la rutina de parpadeo
		StartCoroutine (HandleLightFlicker ());
	}

	IEnumerator HandleLightFlicker ()
	{
		while (true) {
			// Esperar un tiempo aleatorio antes de apagar
			float waitTime = Random.Range (minTime, maxTime);
			yield return new WaitForSeconds (waitTime);

			// Parpadeo de la luz
			for (int i = 0; i < flickerCount; i++) {
				lightComponent.enabled = false;
				yield return new WaitForSeconds (flickerDuration);
				lightComponent.enabled = true;
				yield return new WaitForSeconds (flickerDuration);
			}
		}
	}
}
