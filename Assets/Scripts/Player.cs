using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {
	public int player = 1;
	public string closeButton = "p1 close";

	[NonSerialized] // ideally we would want a property with private set, but unity3d uses old c#
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
