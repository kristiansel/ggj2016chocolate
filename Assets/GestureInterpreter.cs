using UnityEngine;
using System.Collections;

public class GestureInterpreter : MonoBehaviour {
	void Start() {
		Messenger.AddListener<BroadcastCollision, BroadcastCollision, Vector2> ("collision", Broadcast);
	}

	void Broadcast(BroadcastCollision b1, BroadcastCollision b2, Vector2 velocity) {
		Gestures? gesture = InterpretCollision (b1, b2);
		if (gesture != null) {
			Debug.Log("Gesture detected: " + gesture.ToString()); 
			Messenger.Broadcast<Gestures> (Events.Gesture, gesture.Value);
		} else {
			Debug.Log ("Unknown collision");
		}
	}

	Gestures? InterpretCollision(BroadcastCollision b1, BroadcastCollision b2) {
		if (b1.type == "fist fingers" && b2.type == "fist fingers") {
			return Gestures.VerticalFistBump;
		} else if (b1.type == "palm top" && b2.type == "palm bottom") {
			return b1.gameObject.GetComponentInParent<Player>().player == 1 ?
				Gestures.FistHammerRightTop : Gestures.FistHammerLeftTop;
		} else if (b2.type == "palm top" && b1.type == "palm bottom") {
			return b1.gameObject.GetComponentInParent<Player>().player == 1 ?
				Gestures.FistHammerLeftTop : Gestures.FistHammerRightTop;
		} else {
			return null;
		}
	}
}
