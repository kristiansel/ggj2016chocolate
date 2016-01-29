using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";
	public float force = 1;

    void FixedUpdate() {
		float x = Input.GetAxis (horizontalAxis);
		float y = Input.GetAxis (verticalAxis);
		Vector3 offset = new Vector3 (x, y, 0) * Time.fixedDeltaTime * force;
		transform.position = transform.position + offset;
    }
}
