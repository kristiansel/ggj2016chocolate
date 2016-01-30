using UnityEngine;
using System.Collections;


// This setup only works with:
//  Import --> Rig --> Animation Type  = Legacy
//  Import --> Animations --> Wrap mode = Loop
public class AnimateHand : MonoBehaviour
{
	public string closeButton = "p1 close";

	private Animation anim;
	private string state = "Handshake";
	private string lastState = "";

	public GameObject fistFingers;

	void Start() {
		anim = GetComponent<Animation>();
	}

    void Update() {
		var closed = Mathf.Abs(Input.GetAxis(closeButton)) > 0.4;

		if (closed) {
			state = "FistVertical";
		} else {
			state = "Handshake";
		}

		//only start new animation if state changed
		if (lastState != state) {
			anim.CrossFade (state, 0.2f);
			fistFingers.SetActive (closed);
			lastState = state;
		}

	}
}
