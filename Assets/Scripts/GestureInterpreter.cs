using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;

public static class GestureInterpreterExtensions
{
	public static float IsGesture(this Gestures gesture, BroadcastCollision b1, BroadcastCollision b2, Vector2 velocity)
	{
		switch (gesture) {
		case Gestures.FistHammerLeftTop: return IsFistHammerLeftTop (b1, b2, velocity);
		case Gestures.FistHammerRightTop: return IsFistHammerRightTop (b1, b2, velocity);
		case Gestures.VerticalFistBump: return IsVerticalFistBump (b1, b2, velocity);
		default: throw new ArgumentOutOfRangeException();
		}
	}

	private static bool HandsHavePose(BroadcastCollision b1, BroadcastCollision b2, string pose) {
		return b1.player.state == pose && b2.player.state == pose;
	}

	public static float IsFistHammerLeftTop(BroadcastCollision b1, BroadcastCollision b2, Vector2 velocity) {
		if (b1.type != "palm bottom" || b2.type != "palm top" || !HandsHavePose(b1, b2, "FistVertical")) {
			return 0;
		}
		//the more downwards, the better the score
		return Vector2.Dot (velocity.normalized, Vector2.down);
	}

	public static float IsFistHammerRightTop(BroadcastCollision b1, BroadcastCollision b2, Vector2 velocity) {
		if (b1.type != "palm top" || b2.type != "palm bottom" || !HandsHavePose(b1, b2, "FistVertical")) {
			return 0;
		}
		return Vector2.Dot (velocity.normalized, Vector2.up);
	}

	public static float IsVerticalFistBump(BroadcastCollision b1, BroadcastCollision b2, Vector2 velocity) {
		if (b1.type != "fist fingers" || b2.type != "fist fingers" || !HandsHavePose(b1, b2, "FistVertical")) {
			return 0;
		}
		return Vector2.Dot (velocity.normalized, Vector2.right);
	}
}

public class GestureInterpreter : MonoBehaviour {

	void Start() {
		Messenger.AddListener<BroadcastCollision, BroadcastCollision, Vector2> ("collision", InterpretCollision);
	}

	void InterpretCollision(BroadcastCollision b1, BroadcastCollision b2, Vector2 velocity) {

		//ugly c#, is there a nicer way?
		var allGestures = Enum.GetValues (typeof(Gestures)).Cast<Gestures>();

		var gesturesAndScores = allGestures
			.Select(g => new { Gesture = g, Score = g.IsGesture(b1, b2, velocity)});
		
		var best = gesturesAndScores.MaxBy (pair => pair.Score);

		if (best.Score > 0.5) {
			Messenger.Broadcast (Events.Gesture, best.Gesture, best.Score);
		} else {
			Debug.Log ("Unknown collision");
		}
	}

}
