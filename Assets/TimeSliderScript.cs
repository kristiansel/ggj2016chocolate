using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeSliderScript : MonoBehaviour {

    public GameLogicMain gameLogicObject;
    private Slider slider;

    // Use this for initialization
    void Start () {
        slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = gameLogicObject.timeLeft;
        slider.maxValue = gameLogicObject.maxTime; // this doesn't need updating every frame, should be event based.
    }
}
