using UnityEngine;
using UnityEngine.UI;

public class UIFadeIn : MonoBehaviour
{
	public float fadeDuration = 2f;
	// Duración del efecto fade in en segundos
	Image fadeImage;
	private float fadeTimer = 0f;

	void Start ()
	{
		fadeImage = this.GetComponent<Image> ();
		if (fadeImage == null) {
			Debug.LogError ("No se asignó una imagen para el efecto de fade in. Por favor, asigna una imagen en el inspector.");
			return;
		}

		// Asegurarse de que la imagen empieza completamente opaca
		Color startColor = fadeImage.color;
		startColor.a = 1f; // Alpha completamente opaco
		fadeImage.color = startColor;

		// Iniciar el proceso de fade in
		StartCoroutine (FadeIn ());
	}

	private System.Collections.IEnumerator FadeIn ()
	{
		while (fadeTimer < fadeDuration) {
			fadeTimer += Time.deltaTime;
			float alpha = Mathf.Lerp (1f, 0f, fadeTimer / fadeDuration); // Lerp para interpolar el alpha

			Color newColor = fadeImage.color;
			newColor.a = alpha;
			fadeImage.color = newColor;

			yield return null; // Esperar al siguiente frame
		}

		// Asegurarse de que el alpha queda en 0 (completamente transparente)
		Color finalColor = fadeImage.color;
		finalColor.a = 0f;
		fadeImage.color = finalColor;
		fadeImage.enabled = false;
	}
}
