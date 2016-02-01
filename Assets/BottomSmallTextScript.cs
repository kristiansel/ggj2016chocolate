using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BottomSmallTextScript : MonoBehaviour {

	private Text textObject;

	// Use this for initialization
	void Start () {
		Messenger.AddListener(Events.CorrectGesture, HandleCorrectGesture); // add argument to this callback indicating qesture quality
		gameObject.SetActive (false);
		textObject = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private static string[] qualityMessages = {
		"Epic fail!",
		"Fail!",
		"Awkward",
		"Decent",
		"Nice",
		"Awsome!",
		"Sick!"
	};
		
	void HandleCorrectGesture()
	{
		gameObject.SetActive (true);

		int message = (int)Random.Range (0, qualityMessages.Length);
		textObject.text = qualityMessages[message];
	}
}
