using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour {
	
	public AudioClip[] successClips;
	private AudioSource source;

	void Start () {
		source = GetComponent<AudioSource> ();
		Messenger.AddListener (Events.CorrectGesture, HandleCorrectGesture);
	}
	
	void HandleCorrectGesture () {
		var index = (int)(Random.value * successClips.Length);
		source.PlayOneShot (successClips [index]);
	}
}
