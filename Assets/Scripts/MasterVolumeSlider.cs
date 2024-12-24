using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterVolumeSlider : MonoBehaviour
{
	public Slider volumeSlider; // Arrastra el Slider en el inspector
	private List<AudioSource> allAudioSources;

	void Start()
	{
		// Encuentra todos los AudioSource en el juego
		allAudioSources = new List<AudioSource>(FindObjectsOfType<AudioSource>());

		// Inicializa el slider con el volumen actual (asume que todos tienen el mismo valor inicial)
		if (allAudioSources.Count > 0)
		{
			volumeSlider.value = allAudioSources[0].volume; // Toma el volumen del primer AudioSource
		}

		// Escucha los cambios del slider
		volumeSlider.onValueChanged.AddListener(SetGlobalVolume);
	}

	// Método para ajustar el volumen de todos los AudioSource
	public void SetGlobalVolume(float volume)
	{
		foreach (var audioSource in allAudioSources)
		{
			audioSource.volume = volume;
		}
	}

	// Método para actualizar la lista si se crean nuevos AudioSources en tiempo de ejecución
	public void UpdateAudioSources()
	{
		allAudioSources = new List<AudioSource>(FindObjectsOfType<AudioSource>());
	}
}
