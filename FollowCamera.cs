using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public GameObject targetGameObject;
	public bool orbitY;
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
			if (targetGameObject != null) {
				transform.LookAt (targetGameObject.transform);
				if (orbitY) {
					transform.RotateAround (targetGameObject.transform.position, Vector3.up, -Time.deltaTime * 10);
				}
			}
		} else if (isDragging) {
			Vector3 currentMousePosition = Input.mousePosition;
			Vector3 mousePositionDelta = currentMousePosition - initialMousePosition;

			transform.RotateAround(targetGameObject.transform.position, Vector3.up, mousePositionDelta.x/7);

			float remainingUpperMargin = 3.5f - transform.position.y;
			float remainingLowerMargin = 0.5f - transform.position.y;
			Debug.Log(mousePositionDelta.y);
			if (mousePositionDelta.y > 0) {
				transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Max(-mousePositionDelta.y/50, remainingLowerMargin), transform.position.z);
			} else {
				transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Min(-mousePositionDelta.y/50, remainingUpperMargin), transform.position.z);
			}
			transform.LookAt (targetGameObject.transform);

			initialMousePosition = currentMousePosition;
		}
	}
}
