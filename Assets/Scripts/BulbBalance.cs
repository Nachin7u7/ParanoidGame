using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbBalance : MonoBehaviour
{
	public Vector3 force;
	public float frequency;

	void Start ()
	{
		StartCoroutine (ApplyForcePeriodically ());
	}

	IEnumerator ApplyForcePeriodically ()
	{
		while (true) {
			
			if (transform.childCount > 0) {
				Transform lastChild = transform.GetChild (transform.childCount - 1);
				Rigidbody rb = lastChild.GetComponent<Rigidbody> ();
				if (rb != null) {
					rb.AddForce (force, ForceMode.Impulse);
				}
			}

			yield return new WaitForSeconds (frequency);
		}
	}

	void Update ()
	{
		
	}
}
