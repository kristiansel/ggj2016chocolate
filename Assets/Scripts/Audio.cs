using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour {
	
	public AudioClip[] successClips;
	public AudioClip[] failClips;
	public AudioClip[] bumpClips;

	private AudioSource source;

	void Start () {
		source = GetComponent<AudioSource> ();
//		Messenger.AddListener (Events.CorrectGesture, HandleCorrectGesture);
//		Messenger.AddListener (Events.IncorrectGesture, HandleIncorrectGesture);
		Messenger.AddListener<BroadcastCollision, BroadcastCollision, Vector2> (Events.Collision, HandleCollision);
	}
	
	void HandleCorrectGesture() {
		int index = (int)Random.Range (0, successClips.Length);
		source.PlayOneShot (successClips [index]);
	}

	void HandleIncorrectGesture() {
		int index = (int)Random.Range (0, failClips.Length);
		source.PlayOneShot (failClips [index]);
	}

	void HandleCollision (BroadcastCollision b1, BroadcastCollision b2, Vector2 velocity) {
		int index = (int)Random.Range (0, bumpClips.Length);
		source.pitch = 30 / velocity.magnitude;
		source.PlayOneShot (bumpClips [index]);
	}

}
