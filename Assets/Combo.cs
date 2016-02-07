using UnityEngine;
using System.Collections;

public class Combo : MonoBehaviour {
	private GameObject spillernummeren;
	private GameObject spillernummerto;
	private int streak = 0;

	// Use this for initialization
	void Start () {
		spillernummeren = GameObject.Find ("Player 1");
		spillernummerto = GameObject.Find ("Player 2");

		Messenger.AddListener (Events.CorrectGesture, HandleCombo);
		Messenger.AddListener (Events.IncorrectGesture, HandleComboBreak);
	}

	void HandleCombo() {
		streak += 1;

		if (streak % 5 == 0) {
			spillernummeren.GetComponentInChildren<ParticleSystem> ().Play ();
			spillernummerto.GetComponentInChildren<ParticleSystem> ().Play ();
		}
	}

	void HandleComboBreak() {
		streak = 0;
	}
}
