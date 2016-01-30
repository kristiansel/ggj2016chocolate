using UnityEngine;
using System.Collections;

public class CollisionEventFX : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Messenger.AddListener<BroadcastCollision, BroadcastCollision, Vector2>(Events.Collision, OnHandsCollideFX);
	}
	
	void OnHandsCollideFX(BroadcastCollision b1, BroadcastCollision b2, Vector2 v) {
		b1.GetComponentInParent<ParticleSystem> ().Play ();
		b2.GetComponentInParent<ParticleSystem> ().Play ();
	}
}
