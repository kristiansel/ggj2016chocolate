using UnityEngine;
using System.Collections;

public class GameLogicMain : MonoBehaviour {

    public enum GameStates { Waiting, MoveSequence, Freestyle };

    private GameStates gameState = GameStates.Waiting;
    [HideInInspector]
    public float timeLeft
    {
        get;
        private set;
    }
    public float maxTime
    {
        get;
        private set;
    }

    private void resetTime()
    {
        timeLeft = 30.0f;
        maxTime = 30.0f;
    }

    void Start () {
		Messenger.AddListener<Gestures> (Events.Gesture, HandleGesture);
		Messenger.AddListener (Events.CorrectGesture, HandleCorrectGesture);
        resetTime();
	}

    public void StartGameButton()
    {
        Messenger.Broadcast(Events.StartGame);
        resetTime();
        gameState = GameStates.MoveSequence;
		NextGesture ();

        // deactivate button
        // reset game
        // change game mode to sequence etc...
    }

	void Update () {
        if (gameState != GameStates.Waiting)
        {
            if (gameState == GameStates.MoveSequence)
            {
                // increment the timer down
                timeLeft -= Time.deltaTime;

                // check if the timer hit zero --> game over, hide the NextUpUI
				if (timeLeft <= 0) {
					Messenger.Broadcast (Events.GameOver);
				}
            }
        } // if (gameState != GameState.Waiting)
        else // the we are on the menu
        {
            // 
        }
    }

	private Gestures? currentGesture;

	void HandleGesture(Gestures g) {
		if (currentGesture.HasValue && currentGesture.Value == g) {
			Messenger.Broadcast (Events.CorrectGesture);
			NextGesture ();
		}
	}

	void HandleCorrectGesture() {
		maxTime = maxTime * (0.9f);
		timeLeft = maxTime;
	}

	Gestures RandomGesture() {
		var values = Gestures.GetValues(typeof(Gestures));
		int index = (int)(Random.value * values.Length);
		Gestures gesture = (Gestures)values.GetValue(index);
		return gesture;
	}

	private void NextGesture() {
		//select new gesture
		var previousGesture = currentGesture;
		while(currentGesture == previousGesture) {
			currentGesture = RandomGesture ();
		}
		Messenger.Broadcast<Gestures> (Events.NewGesture, currentGesture.Value);
	}
}
