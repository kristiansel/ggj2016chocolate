using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverTextScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Messenger.AddListener (Events.GameOver, HandleGameOver);
		gameObject.SetActive (false);
	}

	void HandleGameOver() {
		gameObject.SetActive (true);
	}
}
