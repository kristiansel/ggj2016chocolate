using UnityEngine;
using System.Collections;

public class AnimateHand : MonoBehaviour
{
    private Animation anim;

    // This setup only works with:
    //  Import --> Rig --> Animation Type  = Legacy
    //  Import --> Animations --> Wrap mode = Loop

    void Start()
    {
        anim = GetComponent<Animation>();
    }
    void Update()
    {
        // Testing crossfade
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.CrossFade("HighFive", 0.2f);
            Debug.Log("Q down");
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            anim.CrossFade("FistHorizontal", 0.2f);
            Debug.Log("Q up");
        }

        // Testing blending
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.Blend("GunFinger", 1.0f, 0.3f);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            anim.Blend("GunFinger", 0.0f, 0.3f);
        }
    }
}