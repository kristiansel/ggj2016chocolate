using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NextMoveImageScript : MonoBehaviour {
	public Sprite[] sprites;
	private Image image;

	void Start () {
		image = gameObject.GetComponent<Image> ();
		Messenger.AddListener<Gestures> (Events.NewGesture, HandleNewGesture);
        Messenger.AddListener(Events.StartSequenceMode, HandleStartSequenceMode);
        Messenger.AddListener(Events.StartFreestyleMode, HandleStartFreestyleMode);
        Messenger.AddListener(Events.StartGame, HandleStartGame);
        Messenger.AddListener(Events.GameOver, HandleGameOver);
        gameObject.SetActive(false);
    }

	void HandleNewGesture (Gestures gesture) {
		image.sprite = GetSpriteForGesture (gesture);
	}

    void HandleStartFreestyleMode()
    {
        gameObject.SetActive(false);
    }

    void HandleStartSequenceMode()
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

    void HandleStartGame()
    {
        gameObject.SetActive(true);
    }

    void HandleGameOver()
    {
        gameObject.SetActive(false);
    }

}
