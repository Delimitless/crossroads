using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	public Transform warpTarget;

	void OnTriggerEnter2D(Collider2D other) {
		other.gameObject.transform.position = warpTarget.position;

		Vector3 newCameraPosition = warpTarget.position;
		newCameraPosition.z = Camera.main.transform.position.z;

		Camera.main.transform.position = newCameraPosition;
	}
}
