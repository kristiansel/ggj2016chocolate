using UnityEngine;
using System.Collections;

public class MoveToAbsolute : MonoBehaviour {

	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";
	public float maxRadius = 5;
	public bool flipHorizontalAxis = false;

	void FixedUpdate() {
		var x = Input.GetAxis (horizontalAxis);
		if (flipHorizontalAxis) {
			x *= -1;
		}
		var y = Input.GetAxis (verticalAxis);
		var direction = Vector3.ClampMagnitude (new Vector3 (x, y, 0), 1);
		transform.localPosition = direction * maxRadius;
	}
}
