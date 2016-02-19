using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeSliderScript : MonoBehaviour {

    public GameLogicMain gameLogicObject;
    private Slider slider;

    // Use this for initialization
    void Start () {
        slider = GetComponent<Slider>();
        Messenger.AddListener(Events.StartGame, HandleStartGame);
        Messenger.AddListener(Events.GameOver, HandleGameOver);
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        slider.value = gameLogicObject.timeLeft;
        slider.maxValue = gameLogicObject.maxTime; // this doesn't need updating every frame, could be event based.
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
