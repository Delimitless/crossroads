using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	public Transform warpTarget;

	public AudioClip exitAudio;
	public AudioClip arrivalAudio;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	IEnumerator OnTriggerEnter2D(Collider2D other) {
		ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader> ();
		AudioSource audioSource = GetComponent<AudioSource> ();

		playAudioIfExists(exitAudio);
		yield return StartCoroutine (sf.FadeToBlack());

		warpToTargetLocation(other);

		playAudioIfExists(arrivalAudio);
		yield return StartCoroutine (sf.FadeToClear());
	}

	void playAudioIfExists(AudioClip clip) {
		if(audioSource != null && clip != null) {
			audioSource.PlayOneShot(clip);
		}
	}

	void warpToTargetLocation(Collider2D warpPassenger) {
		warpPassenger.gameObject.transform.position = warpTarget.position;

		Vector3 newCameraPosition = warpTarget.position;
		newCameraPosition.z = Camera.main.transform.position.z;
		Camera.main.transform.position = newCameraPosition;
	}
}
