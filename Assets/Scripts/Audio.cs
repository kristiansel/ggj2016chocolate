using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour {
	
	public AudioClip[] successClips;
	public AudioClip[] bumpClips;
	private AudioSource source;

	void Start () {
		source = GetComponent<AudioSource> ();
		Messenger.AddListener (Events.CorrectGesture, HandleCorrectGesture);
		Messenger.AddListener<BroadcastCollision, BroadcastCollision, Vector2> (Events.Collision, HandleCollision);
	}
	
	void HandleCorrectGesture () {
		var index = (int)(Random.value * successClips.Length);
		source.PlayOneShot (successClips [index]);
	}

	void HandleCollision (BroadcastCollision b1, BroadcastCollision b2, Vector2 velocity) {
		var index = (int)(Random.value * bumpClips.Length);
		source.PlayOneShot (bumpClips [index]);
	}

}
