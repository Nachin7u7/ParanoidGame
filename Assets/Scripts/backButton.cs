using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backButton : MonoBehaviour
{
	public GameObject actualTab, newTab;

	public void config ()
	{
		newTab.SetActive (true);
		actualTab.SetActive (false);
	}
	////////animation but does not work propietly so TODO later

	//	public float transitionDuration = 0.5f;
	//	// Duración de la animación
	//	CanvasGroup actualTabCanvas;
	//	CanvasGroup newTabCanvas;
	//
	//	void Awake ()
	//	{
	//			actualTabCanvas.alpha = 1f;
	//	}
	//
	//	public void Config ()
	//	{
	//		// Iniciar las animaciones de transición
	//		StartCoroutine (SwitchTabsWithAnimation ());
	//	}
	//
	//	private IEnumerator SwitchTabsWithAnimation ()
	//	{
	//		// Obtener CanvasGroup de las pestañas (añádelo en los GameObjects de las pestañas si no está presente)
	//		actualTabCanvas = actualTab.GetComponent<CanvasGroup> ();
	//		newTabCanvas = newTab.GetComponent<CanvasGroup> ();
	//
	//		// Asegurarse de que ambos CanvasGroup existan
	//		if (actualTabCanvas == null || newTabCanvas == null) {
	//			Debug.LogError ("Las pestañas necesitan un CanvasGroup para animar las transiciones.");
	//			yield break;
	//		}
	//
	//		// Fade out de la pestaña actual
	//		float timer = 0f;
	//		while (timer < transitionDuration) {
	//			timer += Time.deltaTime;
	//			float alpha = Mathf.Lerp (1f, 0f, timer / transitionDuration);
	//			actualTabCanvas.alpha = alpha;
	//			yield return null;
	//		}
	//		actualTabCanvas.alpha = 0f;
	//		actualTab.SetActive (false);
	//
	//		// Activar la nueva pestaña y hacer Fade in
	//		newTab.SetActive (true);
	//		timer = 0f;
	//		while (timer < transitionDuration) {
	//			timer += Time.deltaTime;
	//			float alpha = Mathf.Lerp (0f, 1f, timer / transitionDuration);
	//			newTabCanvas.alpha = alpha;
	//			yield return null;
	//		}
	//		newTabCanvas.alpha = 1f;
	//	}
}
