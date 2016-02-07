using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {
	private AudioSource lyd;
	void Start () {
		lyd = GetComponent<AudioSource> ();
		Messenger.AddListener (Events.FreestyleTriggered, HandleFreestyleTriggered);
	}

	void HandleFreestyleTriggered() {
	}
}
