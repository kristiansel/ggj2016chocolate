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
		int index = (int)Random.Range (0, successClips.Length);
		source.PlayOneShot (successClips [index]);
	}

	void HandleCollision (BroadcastCollision b1, BroadcastCollision b2, Vector2 velocity) {
		int index = (int)Random.Range (0, bumpClips.Length);
		source.PlayOneShot (bumpClips [index]);
	}

}
