using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour {
	
	public AudioClip[] bumpClips;

	private AudioSource source;

	void Start () {
		source = GetComponent<AudioSource> ();
		Messenger.AddListener<BroadcastCollision, BroadcastCollision, Vector2> (Events.Collision, HandleCollision);
	}

	void HandleCollision (BroadcastCollision b1, BroadcastCollision b2, Vector2 velocity) {
		int index = (int)Random.Range (0, bumpClips.Length);
		source.pitch = 30 / velocity.magnitude;
		source.PlayOneShot (bumpClips [index]);
	}

}
