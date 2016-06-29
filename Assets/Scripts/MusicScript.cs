using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicScript : MonoBehaviour {
	private AudioSource lyd;

    public AudioClip[] freestyleClips;
    public AudioClip[] sequenceClips;
	public AudioClip menuClip;

    void Start () {
		lyd = GetComponent<AudioSource> ();
		Messenger.AddListener (Events.StartFreestyleMode, HandleStartFreestyleMode);
		Messenger.AddListener (Events.FreestyleModeOver, HandleFreestyleModeOver);
        Messenger.AddListener (Events.StartSequenceMode, HandleStartSequenceMode);
		Messenger.AddListener (Events.GameOver, HandleGameOver);
		lyd.clip = menuClip;
		lyd.Play();
    }

	void HandleStartFreestyleMode() {
        int index = (int)Random.Range(0, freestyleClips.Length);
        lyd.clip = freestyleClips[index];
        lyd.Play();
    }

    void HandleStartSequenceMode()
    {
        int index = (int)Random.Range(0, sequenceClips.Length);
        lyd.clip = sequenceClips[index];
        lyd.Play();
    }

    // funker ikke for øyeblikket
    void HandleFreestyleModeOver() {
	//	lyd.Stop ();
	}

	void HandleGameOver()
	{
		lyd.clip = menuClip;
		lyd.Play();
	}
}
