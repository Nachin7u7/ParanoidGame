using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resolutionSettings : MonoBehaviour
{
	public Dropdown resolutionDropdown;
	// Assign your dropdown in the inspector
	private Resolution[] resolutions;

	void Start ()
	{
		// Get all available resolutions
		resolutions = Screen.resolutions;

		// Clear the dropdown options
		resolutionDropdown.ClearOptions ();

		// Create a list to hold the resolution strings
		List<string> options = new List<string> ();

		int currentResolutionIndex = 0;

		// Populate the options with available resolutions
		for (int i = 0; i < resolutions.Length; i++) {
			string option = resolutions [i].width + " x " + resolutions [i].height;
			options.Add (option);

			// Check for current resolution
			if (resolutions [i].width == Screen.currentResolution.width &&
			    resolutions [i].height == Screen.currentResolution.height) {
				currentResolutionIndex = i;
			}
		}

		// Add options to dropdown
		resolutionDropdown.AddOptions (options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue ();

		// Add a listener to handle resolution changes
		resolutionDropdown.onValueChanged.AddListener (SetResolution);
	}

	// Method to change resolution
	public void SetResolution (int resolutionIndex)
	{
		Resolution resolution = resolutions [resolutionIndex];
		Screen.SetResolution (resolution.width, resolution.height, Screen.fullScreen);
	}
}
