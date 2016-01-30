using UnityEngine;
using System.Collections;

public class CollisionEventAudio : MonoBehaviour {
	public AudioClip[] audioClips;
	AudioSource audio;
	int num = 0;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();

		Messenger.AddListener<BroadcastCollision, BroadcastCollision, Vector2>(Events.Collision, OnHandsCollideAudio);
	}
		
	// Update is called once per frame
	void OnHandsCollideAudio (BroadcastCollision b1, BroadcastCollision b2, Vector2 v) {
		if (audio.isPlaying) {
			return;
		}	

		audio.clip = audioClips [num % audioClips.Length];
		audio.Play ();

		num++;
	}
}
