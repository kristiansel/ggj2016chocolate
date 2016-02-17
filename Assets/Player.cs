using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int player = 1;
	public string closeButton = "p1 close";
	public string state = "Handshake";

	void Update() {
		var closed = Mathf.Abs (Input.GetAxis (closeButton)) > 0.4;

		if (closed) {
			state = "FistVertical";
		} else {
			state = "Handshake";
		}
	}
}
