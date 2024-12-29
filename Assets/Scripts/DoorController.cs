using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
	public Animator doorAnimator;
	// El componente Animator de la puerta
	public GameObject text;
	// Prefab del texto que se mostrará al jugador
	public Transform canva;
	private GameObject instantiatedText;
	// Instancia del texto
	private bool playerInTrigger = false;
	// Para saber si el jugador está dentro del trigger
	private bool isDoorOpen = false;
	// Estado actual de la puerta (abierta o cerrada)

	private CanvasGroup textCanvasGroup;
	// Para controlar el fade del texto
	public float fadeDuration = 0.5f;
	// Duración del fade in/out

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Player")) { // Asegúrate de que el Player tenga la etiqueta "Player"
			playerInTrigger = true;
			ShowTutorialText (); // Mostrar el texto con fade in
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.CompareTag ("Player")) {
			playerInTrigger = false;
			HideTutorialText (); // Ocultar el texto con fade out
		}
	}

	void Update ()
	{
		if (playerInTrigger && Input.GetKeyDown (KeyCode.E)) {
			if (!isDoorOpen) {
				OpenDoor ();
			} else {
				CloseDoor ();
			}
		}
	}

	void OpenDoor ()
	{
		Debug.Log ("Opening Door");
		doorAnimator.SetTrigger ("Open"); // Activa el trigger "Open" en el Animator
		isDoorOpen = true; // Marca la puerta como abierta
	}

	void CloseDoor ()
	{
		Debug.Log ("Closing Door");
		doorAnimator.SetTrigger ("Close"); // Activa el trigger "Close" en el Animator
		isDoorOpen = false; // Marca la puerta como cerrada
	}

	void ShowTutorialText ()
	{
		if (text != null) {

			if (instantiatedText == null) {
				// Instanciar el texto en pantalla
				instantiatedText = Instantiate (text, canva.transform);

				// Obtener el CanvasGroup o añadirlo si no existe
				textCanvasGroup = instantiatedText.GetComponent<CanvasGroup> ();
				if (textCanvasGroup == null) {
					textCanvasGroup = instantiatedText.AddComponent<CanvasGroup> ();
				}

				// Configurar opacidad inicial y comenzar fade in
				textCanvasGroup.alpha = 0f;
				StartCoroutine (FadeText (textCanvasGroup, 1f, null)); // Fade in hasta 1, sin acción adicional
			}
		}
	}

	void HideTutorialText ()
	{
		if (instantiatedText != null) {
			// Comenzar fade out y destruir el objeto después
			StartCoroutine (FadeText (textCanvasGroup, 0f, delegate {
				Destroy (instantiatedText);
				instantiatedText = null; // Asegurarse de que la referencia sea nula
			}));
		}
	}

	// Corrutina para hacer el fade del texto
	private System.Collections.IEnumerator FadeText (CanvasGroup canvasGroup, float targetAlpha, System.Action onComplete)
	{
		float startAlpha = canvasGroup.alpha;
		float timer = 0f;

		while (timer < fadeDuration) {
			timer += Time.deltaTime;
			canvasGroup.alpha = Mathf.Lerp (startAlpha, targetAlpha, timer / fadeDuration);
			yield return null;
		}

		canvasGroup.alpha = targetAlpha;

		// Llamar a la acción después del fade (opcional)
		if (onComplete != null) {
			onComplete();
		}
	}
}
