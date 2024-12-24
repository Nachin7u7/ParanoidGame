using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtGamer : MonoBehaviour
{

	public GameObject gamer;

	void Update ()
	{
		this.transform.LookAt (gamer.transform);
	}
}
