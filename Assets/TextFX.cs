using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextFX : MonoBehaviour {

	public GameObject SuccessTextPrefab;
	public GameObject FailTextPrefab;

	void Start () {
		Messenger.AddListener(Events.CorrectGesture, HandleCorrectGesture); // add argument to this callback indicating qesture quality
		Messenger.AddListener(Events.IncorrectGesture, HandleIncorrectGesture);
	}

	private static string[] posText = {
		"Decent",
		"Nice",
		"Awesome!",
		"Sick!"
	};

	private static string[] negText = {
		"Epic fail!",
		"Fail!",
		"Awkward",
	};

	void HandleCorrectGesture() {
		int message = (int)Random.Range (0, posText.Length);
		InitTextObject (posText [message], true);
	}

	void HandleIncorrectGesture() {
		int message = (int)Random.Range (0, negText.Length);
		InitTextObject(negText [message], false);
	}

	void InitTextObject(string text, bool success) {
		GameObject prefab;

		if (success) {
			prefab = SuccessTextPrefab;
		} else {
			prefab = FailTextPrefab;
		}

		GameObject temp = Instantiate (prefab) as GameObject;
		RectTransform tempRect = temp.GetComponent<RectTransform> ();

		temp.transform.SetParent (this.transform);
		temp.GetComponent<Text> ().text = text;

		tempRect.transform.localPosition = prefab.transform.localPosition;
		tempRect.transform.localRotation = prefab.transform.localRotation;
		tempRect.transform.localScale = prefab.transform.localScale;

		Destroy (temp, 2.0f);
	}
}
