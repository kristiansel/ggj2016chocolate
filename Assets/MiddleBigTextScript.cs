using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiddleBigTextScript : MonoBehaviour {

    private Text textObject;

	// Use this for initialization
	void Start () {
		Messenger.AddListener (Events.GameOver, HandleGameOver);
        Messenger.AddListener (Events.StartSequenceMode, HandleStartSequenceMode);
        Messenger.AddListener (Events.StartFreestyleMode, HandleStartFreestyleMode);
        gameObject.SetActive (false);
        textObject = GetComponent<Text>();
	}

	void HandleGameOver() {
        textObject.text = "GAME OVER";
		gameObject.SetActive (true);
	}

    void HandleStartSequenceMode()
    {
        gameObject.SetActive(false);
    }

    void HandleStartFreestyleMode()
    {
        gameObject.SetActive(true);
        textObject.text = "Freestyle!";
    }
}
