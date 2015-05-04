using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	public Transform warpTarget;

	IEnumerator OnTriggerEnter2D(Collider2D other) {

		ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader> ();

		yield return StartCoroutine (sf.FadeToBlack());

		other.gameObject.transform.position = warpTarget.position;
		Vector3 newCameraPosition = warpTarget.position;
		newCameraPosition.z = Camera.main.transform.position.z;
		Camera.main.transform.position = newCameraPosition;

		yield return StartCoroutine (sf.FadeToClear());
	}
}
