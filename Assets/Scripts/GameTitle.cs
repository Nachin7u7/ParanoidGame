using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameTitle : MonoBehaviour
{
	public Text titleText;
	// El texto que mostrará el título
	public Image titleImage;
	// La imagen que aparecerá después
	public float fadeDuration = 1f;
	// Duración del fade in/out
	public float displayDuration = 2f;
	// Tiempo que el texto o imagen se mantiene visible
	public float stretchAmount = 1.2f;
	// Factor de estiramiento vertical (1.2 = 20% más alto)
	public float shakeIntensity = 5f;
	// Intensidad del movimiento errático
	public float shakeSpeed = 20f;
	// Velocidad del movimiento errático
	public AudioClip authorSound, titleSound;
	private AudioSource audioS;
	// Inicia el proceso
	void Start ()
	{
		audioS = GetComponent<AudioSource> ();
		audioS.playOnAwake = false;
		audioS.volume = 1f;
		StartCoroutine (ShowGameTitleSequence ());
	}

	private IEnumerator ShowGameTitleSequence ()
	{
		// Asegurarse de que el texto y la imagen sean invisibles al inicio
		SetAlpha (titleText, 0);
		SetAlpha (titleImage, 0);

		yield return new WaitForSeconds (2f);

		// Fade in del texto con agitación
		StartCoroutine (ShakeText (titleText, displayDuration + 2)); // Activar movimiento errático
		yield return StartCoroutine (FadeIn (titleText));
		yield return new WaitForSeconds (displayDuration);

		// Fade out del texto
		yield return StartCoroutine (FadeOut (titleText));

		// Fade in de la imagen con estiramiento y vibración
		StartCoroutine (ShakeImage (titleImage, displayDuration)); // Vibración errática
		yield return StartCoroutine (FadeInAndStretch (titleImage));

		// Mantener la imagen visible mientras vibra
		yield return new WaitForSeconds (displayDuration);

		// Fade out de la imagen (se mantiene estirada)
		yield return StartCoroutine (FadeOut (titleImage));
		Application.Quit (); //take this out when game is in develop
	}

	private IEnumerator FadeIn (Graphic graphic)
	{
		audioS.clip = authorSound;
		audioS.Play ();
		float timer = 0f;
		Color color = graphic.color;
		while (timer < fadeDuration) {
			timer += Time.deltaTime;
			color.a = Mathf.Lerp (0f, 1f, timer / fadeDuration);
			graphic.color = color;
			yield return null;
		}
		// Asegurarse de que el alfa sea completamente visible
		color.a = 1f;
		graphic.color = color;
	}

	// Realiza un fade in y estira la imagen
	private IEnumerator FadeInAndStretch (Image image)
	{
		audioS.clip = titleSound;
		audioS.Play ();
		float timer = 0f;
		Color color = image.color;
		RectTransform rectTransform = image.GetComponent<RectTransform> ();

		Vector3 originalScale = rectTransform.localScale;
		Vector3 stretchedScale = new Vector3 (originalScale.x, originalScale.y * stretchAmount, originalScale.z);

		while (timer < fadeDuration) {
			timer += Time.deltaTime;
			color.a = Mathf.Lerp (0f, 1f, timer / fadeDuration);
			rectTransform.localScale = Vector3.Lerp (originalScale, stretchedScale, timer / fadeDuration);
			image.color = color;
			yield return null;
		}

		// Asegurarse de que el alfa y el tamaño estén completamente visibles/estirados
		color.a = 1f;
		rectTransform.localScale = stretchedScale;
		image.color = color;
	}

	// Realiza un fade out en cualquier elemento UI (Text o Image)
	private IEnumerator FadeOut (Graphic graphic)
	{
		float timer = 0f;
		Color color = graphic.color;
		while (timer < fadeDuration) {
			timer += Time.deltaTime;
			color.a = Mathf.Lerp (1f, 0f, timer / fadeDuration);
			graphic.color = color;
			yield return null;
		}
		// Asegurarse de que el alfa sea completamente invisible
		color.a = 0f;
		graphic.color = color;
	}

	// Establece la opacidad inicial (alfa) de un elemento UI
	private void SetAlpha (Graphic graphic, float alpha)
	{
		Color color = graphic.color;
		color.a = alpha;
		graphic.color = color;
	}

	// Efecto de movimiento errático en el texto
	private IEnumerator ShakeText (Text text, float duration)
	{
		//RectTransform rectTransform = text.GetComponent<RectTransform> ();
		//Vector3 originalPosition = rectTransform.localPosition; // Posición original
		float timer = 0f;

		while (timer < duration) {
			timer += Time.deltaTime;

			// Movimiento errático en X e Y
			float offsetX = Mathf.PerlinNoise (timer * shakeSpeed, 0f) * 2f - 1f; // Perlin Noise para suavidad
			float offsetY = Mathf.PerlinNoise (0f, timer * shakeSpeed) * 2f - 1f;
			offsetX *= shakeIntensity;
			offsetY *= shakeIntensity;

			//rectTransform.localPosition = originalPosition + new Vector3 (offsetX, offsetY, 0f);

			yield return null;
		}

		// Restaurar la posición original
		//rectTransform.localPosition = originalPosition;
	}

	// Efecto de vibración errática en la imagen
	private IEnumerator ShakeImage (Image image, float duration)
	{
		RectTransform rectTransform = image.GetComponent<RectTransform> ();
		Vector3 originalPosition = rectTransform.localPosition;
		float timer = 0f;

		while (timer < duration) {
			timer += Time.deltaTime;

			// Movimiento errático con pausas aleatorias
			if (Random.value > 0.8f) { // Probabilidad de detenerse momentáneamente
				yield return new WaitForSeconds (0.1f);
			}

			// Movimiento errático en X e Y
			float offsetX = Random.Range (-shakeIntensity, shakeIntensity);
			float offsetY = Random.Range (-shakeIntensity, shakeIntensity);
			rectTransform.localPosition = originalPosition + new Vector3 (offsetX, offsetY, 0f);

			yield return null;
		}

		// Restaurar la posición original
		rectTransform.localPosition = originalPosition;
	}
}
