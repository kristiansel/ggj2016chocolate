using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {
	public int player = 1;
	public string closeButton = "p1 close";
	public string rotateUpButton = "p1 rotate up";
	public string rotateDownButton = "p1 rotate down";

	private enum Rotation { Up = 1, Vertical = 0, Down = -1 }

	[NonSerialized] // ideally we would want a property with private set, but unity3d uses old c#
	public string state = "Handshake";

	void Update() {
		var closed = Mathf.Abs (Input.GetAxis (closeButton)) > 0.4;

		int r = 0;
		if(Input.GetButton(rotateUpButton)) {
			++r;
		}
		if (Input.GetButton (rotateDownButton)) {
			--r;
		}
		var rotation = (Rotation)r;
		if (closed) {
			state = "FistVertical";
		} else {
			switch (rotation) {
			case Rotation.Up:
				state = "FlatUp";
				break;
			case Rotation.Vertical:
				state = "Handshake";
				break;
			case Rotation.Down:
				state = "FlatDown";
				break;
			}
		}
	}
}
