using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otroDeMoverObjetos : MonoBehaviour
{

	public GameObject musica;
	public GameObject sonidoRoto;
	public GameObject player;
	public GameObject nuevoPunto;
	public List<ParticleSystem> BrokenLight;
	AudioSource sonido;
	bool aux;
	// Use this for initialization
	void Start ()
	{
		foreach (ParticleSystem ps in BrokenLight)
			ps.Stop ();
	}


	private void OnTriggerEnter (Collider other)
	{
		
		if (musica != null || player != null || nuevoPunto != null || sonidoRoto != null) {
			sonido = musica.GetComponent<AudioSource> ();
			aux = sonido.mute;

			if (player.tag.Equals ("Player") && aux) {
				player.transform.position = new Vector3 (player.transform.position.x,
					player.transform.position.y,
					nuevoPunto.transform.position.z);

				GameObject sound = Instantiate (sonidoRoto);
				sound.transform.position = new Vector3 (player.transform.position.x,
					player.transform.position.y,
					player.transform.position.z);
				
				foreach (ParticleSystem ps in BrokenLight)
					ps.Play ();

				// Configurar el modo y parámetros de la niebla
				RenderSettings.fogColor = new Color (0.1f, 0.1f, 0.1f); 
				RenderSettings.fogMode = FogMode.Linear; 
				RenderSettings.fogStartDistance = 1f;  
				RenderSettings.fogEndDistance = 15f;    
				RenderSettings.fogDensity = 0.01f;    

			}
		}
	}

}
