using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public GameObject score_text_obj;

	private int score;
	private Text score_text;

	// Use this for initialization
	void Start () {
		// Messenger.AddListener (Events.GameOver, HandleGameOver);
		Messenger.AddListener (Events.StartGame, HandleStartGame);
		Messenger.AddListener (Events.StartSequenceMode, HandleStartSequenceMode);
		Messenger.AddListener (Events.StartFreestyleMode, HandleStartFreestyleMode);
		Messenger.AddListener (Events.CorrectGesture, HandleCorrectGesture);
		gameObject.SetActive (false);
		score_text = score_text_obj.GetComponent<Text>();

		score = 0;
	}
	
	// Update is called once per frame
	void UpdateScoreText() {
		score_text.text = score.ToString();
	}

	void HandleStartGame()
	{
		// reset the score counter
		score = 0;
		UpdateScoreText ();
	}

	void HandleStartSequenceMode()
	{
		gameObject.SetActive(true);
	}

	void HandleStartFreestyleMode()
	{
		gameObject.SetActive(true);
	}

	void HandleCorrectGesture()
	{
		score += 1;
		UpdateScoreText ();
	}
}
