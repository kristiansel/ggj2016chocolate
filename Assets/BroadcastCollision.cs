using UnityEngine;
using System.Collections;

public class BroadcastCollision : MonoBehaviour {
	public string colliderType = "fistFingers";

	private static float lastCollision = 0;
	private const float minimumCollisionInterval = 0.5f;

	void OnCollisionEnter2D(Collision2D collision) {
		var t = Time.time;
		if (lastCollision + minimumCollisionInterval > t) {
			return;
		}
		lastCollision = t;

		var thisCollider = GetComponent<Collider2D> ();
		var velocity = collision.relativeVelocity;

		Debug.Log ("TODO: broadcast collision: " + collision.collider + thisCollider + velocity);
	}
}
