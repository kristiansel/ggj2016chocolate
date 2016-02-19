using UnityEngine;
using System.Collections;


// This setup only works with:
//  Import --> Rig --> Animation Type  = Legacy
//  Import --> Animations --> Wrap mode = Loop
public class AnimateHand : MonoBehaviour
{
	private string lastState = "";
	private Animation anim;
	private Player player;

	public GameObject fistFingers;

	void Start() {
		anim = GetComponent<Animation>();
		player = GetComponentInParent<Player> ();
	}

    void Update() {
		//only start new animation if state changed
		if (player.state != lastState) {
			anim.CrossFade (player.state, 0.2f);
			fistFingers.SetActive (player.state == "FistVertical");
			lastState = player.state;
		}
	}
}
