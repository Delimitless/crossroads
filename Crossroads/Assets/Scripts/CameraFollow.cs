using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	const float CAMERA_ZOOM_SCALE = 4f;
	const float CAMERA_FOLLOW_RATE = 0.1f;

	public Transform target;
	Camera cam;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Scale camera size based on screen size, so all devices show same number of pixels.
		cam.orthographicSize = ((Screen.height / 100f) / CAMERA_ZOOM_SCALE);

		// Follow the target
		if (target) {
			Vector3 fromPosition = transform.position;

			Vector3 toPosition = new Vector3();
			toPosition.x = target.position.x;
			toPosition.y = target.position.y;
			toPosition.z = fromPosition.z;

			transform.position = Vector3.Lerp(fromPosition, toPosition, CAMERA_FOLLOW_RATE);
		}
	}
}
