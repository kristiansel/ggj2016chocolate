using UnityEngine;
using System.Collections;

public class GestureInterpreter : MonoBehaviour {
	void Start() {
		Messenger.AddListener<BroadcastCollision, BroadcastCollision, Vector2> ("collision", Broadcast);
	}

	void Broadcast(BroadcastCollision b1, BroadcastCollision b2, Vector2 velocity) {
		if (b1.type == "fist fingers" && b2.type == "fist fingers") {
			Messenger.Broadcast<Gestures> (Events.Gesture, Gestures.VerticalFistBump);
		}
	}
}
