using UnityEngine;
using System.Collections;

public class CollisionEventAudio : MonoBehaviour {
	public AudioClip[] audioClips;
	AudioSource lyd;
	int num = 0;

	// Use this for initialization
	void Start () {
		lyd = GetComponent<AudioSource> ();

		Messenger.AddListener<BroadcastCollision, BroadcastCollision, Vector2>(Events.Collision, OnHandsCollideAudio);
	}
		
	// Update is called once per frame
	void OnHandsCollideAudio (BroadcastCollision b1, BroadcastCollision b2, Vector2 v) {
		if (lyd.isPlaying) {
			return;
		}	

		lyd.clip = audioClips [num % audioClips.Length];
		lyd.Play ();

		num++;
	}
}
