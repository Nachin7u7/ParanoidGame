using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class windowedSettings : MonoBehaviour
{
	public Toggle fullscreenToggle;
	// Assign your toggle in the inspector

	void Start ()
	{
		// Set the toggle to the current fullscreen state
		fullscreenToggle.isOn = Screen.fullScreen;

		// Add a listener to detect changes in the toggle
		fullscreenToggle.onValueChanged.AddListener (SetFullscreen);
	}

	// Method to toggle fullscreen
	public void SetFullscreen (bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;
	}
}
