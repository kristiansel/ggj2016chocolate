using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicScript : MonoBehaviour {
	private AudioSource lyd;

    public AudioClip[] freestyleClips;
    public AudioClip[] sequenceClips;

    void Start () {
		lyd = GetComponent<AudioSource> ();
		Messenger.AddListener (Events.FreestyleTriggered, HandleFreestyleTriggered);
		Messenger.AddListener (Events.FreestyleOver, HandleFreestyleOver);
        Messenger.AddListener (Events.StartGame, HandleStartSequence);
    }

	void HandleFreestyleTriggered() {
        int index = (int)Random.Range(0, freestyleClips.Length);
        lyd.clip = freestyleClips[index];
        lyd.Play();
    }

    void HandleStartSequence()
    {
        int index = (int)Random.Range(0, sequenceClips.Length);
        lyd.clip = sequenceClips[index];
        lyd.Play();
    }

    // funker ikke for øyeblikket
    void HandleFreestyleOver() {
	//	lyd.Stop ();
	}
}
