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

		var thisPlayer = GetComponentInParent<Player> ().player;
		var b1 = thisPlayer == 1 ? this : otherBroadcast;
		var b2 = thisPlayer == 2 ? this : otherBroadcast;
		var velocity = (thisPlayer == 1 ? 1 : -1) * collision.relativeVelocity;
		Debug.Log (velocity);

		Messenger.Broadcast<BroadcastCollision, BroadcastCollision, Vector2> (Events.Collision, b1, b2, velocity);
	}
}
