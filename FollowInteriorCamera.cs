using UnityEngine;
using System.Collections;

public class FollowInteriorCamera : MonoBehaviour {

	bool isDragging;
	Vector3 initialMousePosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			isDragging = true;
			initialMousePosition = Input.mousePosition;
		} else if (Input.GetMouseButtonUp (0)) {
			isDragging = false;
		} else if (!isDragging) {
			transform.RotateAround (transform.position, Vector3.up, -Time.deltaTime * 10);
		} else if (isDragging) {
			Vector3 currentMousePosition = Input.mousePosition;
			Vector3 mousePositionDelta = currentMousePosition - initialMousePosition;
			transform.RotateAround(gameObject.transform.position, Vector3.up, -mousePositionDelta.x/10);
			transform.RotateAround(gameObject.transform.position, gameObject.transform.right, mousePositionDelta.y/10);

			initialMousePosition = currentMousePosition;
		}
	}
}
