using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{

	// La imagen del canvas UI que hará el fade in
	public float fadeDuration = 2f;
	// Duración del efecto fade in en segundos
	public Image fadeImage;
	private float fadeTimer = 0f;
	public GameObject actualTab, newTab;
	void Start ()
	{
		if (fadeImage == null) {
			Debug.LogError ("No se asignó una imagen para el efecto de fade in. Por favor, asigna una imagen en el inspector.");
			return;
		}

		//Color startColor = fadeImage.color;
		//startColor.a = 0f; // Alpha completamente transparente
		//fadeImage.color = startColor;
	}

	public void loadLvl (string lvlName)
	{
		StartCoroutine (StartCounter (lvlName));
	}

	public void config ()
	{
		newTab.SetActive (true);
		actualTab.SetActive (false);
	}

	public void exitGame ()
	{
		Application.Quit ();
	}

	private IEnumerator StartCounter (string lvlName)
	{
		StartCoroutine (FadeIn ());
		yield return new WaitForSeconds (fadeDuration);
		Application.LoadLevel (lvlName);
	}

	private System.Collections.IEnumerator FadeIn ()
	{
		// Asegúrate de que la imagen está habilitada
		fadeImage.enabled = true;

		while (fadeTimer < fadeDuration) {
			fadeTimer += Time.deltaTime;
			float alpha = Mathf.Lerp (0f, 1f, fadeTimer / fadeDuration); // Lerp para aumentar el alpha (de transparente a opaco)

			Color newColor = fadeImage.color;
			newColor.a = alpha;
			fadeImage.color = newColor;

			yield return null; // Esperar al siguiente frame
		}

		// Asegurarse de que el alpha queda en 1 (completamente opaco)
		Color finalColor = fadeImage.color;
		finalColor.a = 1f;
		fadeImage.color = finalColor;
	}

}
