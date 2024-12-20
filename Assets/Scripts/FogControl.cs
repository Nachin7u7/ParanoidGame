using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogControl : MonoBehaviour
{
	public float Start_Distance;
	public float End_Distance;
	public float Density;

	public Color Fog_Color;

	// Use this for initialization
	void Start ()
	{ 
		RenderSettings.fog = true;

		RenderSettings.fogColor = Fog_Color; // Color oscuro (RGB entre 0 y 1)

		// Configurar el modo y parámetros de la niebla
		RenderSettings.fogMode = FogMode.Linear; // Opciones: Linear, Exponential, ExponentialSquared
		RenderSettings.fogStartDistance = Start_Distance;   // Distancia inicial
		RenderSettings.fogEndDistance = End_Distance;    // Distancia final
		RenderSettings.fogDensity = Density;       // Para modos exponenciales
	}
}