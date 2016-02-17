using UnityEngine;
using System.Collections;
using System;

public class BroadcastCollision : MonoBehaviour {
	public string type = "fist fingers";

	private static float lastCollision = 0;
	private const float minimumCollisionInterval = 0.5f;

	public Player player { get; private set; }

	void Start() {
		player = GetComponentInParent<Player> ();
	}

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

		var playerNo = player.player;
		var b1 = playerNo == 1 ? this : otherBroadcast;
		var b2 = playerNo == 2 ? this : otherBroadcast;
		var velocity = (playerNo == 1 ? 1 : -1) * collision.relativeVelocity;

		Messenger.Broadcast<BroadcastCollision, BroadcastCollision, Vector2> (Events.Collision, b1, b2, velocity);
	}
}
