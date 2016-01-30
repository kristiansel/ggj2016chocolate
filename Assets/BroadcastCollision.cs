using UnityEngine;
using System.Collections;

public class BroadcastCollision : MonoBehaviour {
	public string type = "fist fingers";

	private static float lastCollision = 0;
	private const float minimumCollisionInterval = 0.5f;

	void OnCollisionEnter2D(Collision2D collision) {
		var otherBroadcast = collision.collider.GetComponent<BroadcastCollision> ();
		if (otherBroadcast == null) {
			return;
		}

		var t = Time.time;
		if (lastCollision + minimumCollisionInterval > t) {
			return;
		}
		lastCollision = t;

		var thisCollider = GetComponent<Collider2D> ();
		var velocity = collision.relativeVelocity;

		Messenger.Broadcast<BroadcastCollision, BroadcastCollision, Vector2> (Events.Collision, this, otherBroadcast, velocity);
	}
}
