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
        resetTime();
	}

    public void StartGameButton()
    {
        Messenger.Broadcast(Events.StartGame);
        resetTime();
        gameState = GameStates.MoveSequence;

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

	void HandleGesture(Gestures g) {
		// send the success signal that triggers a new move or freestyle mode
		maxTime = maxTime * (0.9f);
		timeLeft = maxTime;

		// set time equal to maxtime
		// switch new target move
	}
}
