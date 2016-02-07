using UnityEngine;
using System.Collections;

public class Combo : MonoBehaviour {
	private int streak = 0;

	// Use this for initialization
	void Start () {
		Messenger.AddListener (Events.CorrectGesture, HandleCombo);
		Messenger.AddListener (Events.IncorrectGesture, HandleComboBreak);
	}

	void HandleCombo() {
		streak += 1;
		Debug.Log (streak);
	}

	void HandleComboBreak() {
		streak = 0;
	}
}
