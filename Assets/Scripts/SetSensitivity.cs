using UnityEngine;
using UnityEngine.UI;

public class SetSensitivity : MonoBehaviour
{
	public Slider sensitivitySlider;
	// El slider UI
	public Settings settings;
	// El ScriptableObject donde se guarda la sensibilidad
	public FPS_Controller ct;

	void Start ()
	{
		// Configurar el valor inicial del slider con el valor guardado en Settings
		sensitivitySlider.value = settings.Sensitivity;

		// Suscribirse al evento del slider para detectar cambios
		sensitivitySlider.onValueChanged.AddListener (OnSensitivityChanged);
	}

	// Método llamado cuando el valor del slider cambia
	public void OnSensitivityChanged (float value)
	{
		// Actualizar el valor de sensibilidad en el ScriptableObject
		settings.Sensitivity = value;
		ct.SetSensitivity ();
	}

	// Desuscribirse para evitar errores de memoria
	void OnDestroy ()
	{
		sensitivitySlider.onValueChanged.RemoveListener (OnSensitivityChanged);
	}
}
