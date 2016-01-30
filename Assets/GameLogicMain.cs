using UnityEngine;
using System.Collections;

public class GameLogicMain : MonoBehaviour {

    public enum GameStateEnum { Waiting, MoveSequence, Freestyle };

    // should ideally be read-only for outside classes
    // private GameState gameState = GameState.Waiting; // default to menu
    public GameStateEnum gameState = GameStateEnum.MoveSequence; // default to MoveSequence
    public float timeLeft = 30.0f; // 30 seconds to complete the first move
    public float maxTime = 30.0f; // 30 seconds to complete the first move

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (gameState != GameStateEnum.Waiting)
        {
            // temporary code to test move-success, space is the cheat key
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("hit space");
                // space is a placeholder "cheat key" for completing the "next move"

                // send the success signal that triggers a new move or freestyle mode
                maxTime = maxTime * (0.9f);
                timeLeft = maxTime;

                    // set time equal to maxtime
                    // switch new target move
            }

            if (gameState == GameStateEnum.MoveSequence)
            {
                // increment the timer down
                timeLeft -= Time.deltaTime;

                // check if the timer hit zero --> game over, hide the NextUpUI
            }
        } // if (gameState != GameState.Waiting)
    }
}
