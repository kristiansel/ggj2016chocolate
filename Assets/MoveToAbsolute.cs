using UnityEngine;
using System.Collections;

public class MoveToAbsolute : MonoBehaviour {

	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";
	public float maxRadius = 5;
	public bool flipHorizontalAxis = false;

	void FixedUpdate() {
		float x = Input.GetAxis (horizontalAxis);
		if (flipHorizontalAxis) {
			x *= -1;
		}
		float y = Input.GetAxis (verticalAxis);
		transform.localPosition = new Vector3 (x, y, 0).normalized * maxRadius;
	}
}
