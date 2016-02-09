using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

	private Rigidbody2D aiai;

	// Use this for initialization
	void Start () {
		aiai = GetComponent<Rigidbody2D> ();
		Messenger.AddListener<BroadcastCollision, BroadcastCollision, Vector2> (Events.Collision, ShakeScreen);
	}

	void ShakeScreen(BroadcastCollision b1, BroadcastCollision b2, Vector2 v) {
		aiai.AddForce (v * 10);
	}
}
