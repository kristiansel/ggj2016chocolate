using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NextMoveImageScript : MonoBehaviour {
	public Sprite[] sprites;
	private Image image;

	void Start () {
		image = gameObject.GetComponent<Image> ();
		Messenger.AddListener<Gestures> (Events.NewGesture, HandleNewGesture);
	}

	void HandleNewGesture (Gestures gesture) {
		image.sprite = GetSpriteForGesture (gesture);
	}

	Sprite GetSpriteForGesture(Gestures gesture) {
		foreach (var sprite in sprites) {
			if (sprite.name == gesture.ToString ()) {
				return sprite;
			}
		}
		return null;
	}

}
