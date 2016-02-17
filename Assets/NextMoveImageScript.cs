using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NextMoveImageScript : MonoBehaviour {
	public Sprite[] sprites;
	private Image image;

	void Start () {
		image = gameObject.GetComponent<Image> ();
		Messenger.AddListener<Gestures> (Events.NewGesture, HandleNewGesture);
        Messenger.AddListener(Events.StartGame, HandleStartGame);
        Messenger.AddListener(Events.StartFreestyleMode, HandleStartFreestyleMode);
    }

	void HandleNewGesture (Gestures gesture) {
		image.sprite = GetSpriteForGesture (gesture);
	}

    void HandleStartFreestyleMode()
    {
        gameObject.SetActive(false);
    }

    void HandleStartGame()
    {
        gameObject.SetActive(true);
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
