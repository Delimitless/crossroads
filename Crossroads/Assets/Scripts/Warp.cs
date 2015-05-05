using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	public Transform warpTarget;

	public AudioClip exitAudio;
	public AudioClip arrivalAudio;

	IEnumerator OnTriggerEnter2D(Collider2D other) {
		ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader> ();
		AudioSource audioSource = GetComponent<AudioSource> ();

		audioSource.PlayOneShot(exitAudio);
		yield return StartCoroutine (sf.FadeToBlack());

		warpToTargetLocation(other);

		audioSource.PlayOneShot(arrivalAudio);
		yield return StartCoroutine (sf.FadeToClear());
	}

	void warpToTargetLocation(Collider2D warpPassenger) {
		warpPassenger.gameObject.transform.position = warpTarget.position;

		Vector3 newCameraPosition = warpTarget.position;
		newCameraPosition.z = Camera.main.transform.position.z;
		Camera.main.transform.position = newCameraPosition;
	}
}
