using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicScript : MonoBehaviour {
	private AudioSource lyd;

	void Start () {
		lyd = GetComponent<AudioSource> ();
		Messenger.AddListener (Events.FreestyleTriggered, HandleFreestyleTriggered);
		// Messenger.AddListener (Events.FreestyleEnd, HandleFreestyleEnd);
	}

	void HandleFreestyleTriggered() {
		// jaja
		StartCoroutine (Eh());
	}

	IEnumerator Eh() {
		lyd.Play ();

		yield return new WaitForSeconds (5);

		lyd.Pause();
	}

	// funker ikke for øyeblikket
	void HandleFreestyleEnd() {
		lyd.Stop ();
	}
}
