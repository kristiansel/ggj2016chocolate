using UnityEngine;
using System.Collections;

public class StartGameButtonScript : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Messenger.AddListener(Events.StartGame, HandleStartGame);
        Messenger.AddListener(Events.GameOver, HandleGameOver);
    }

    void HandleGameOver()
    {
        gameObject.SetActive(true);
    }

    void HandleStartGame()
    {
        gameObject.SetActive(false);
    }
}
