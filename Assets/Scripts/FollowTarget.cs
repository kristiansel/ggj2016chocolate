using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

	public float maxForce = 20;
	public Transform target;

	private Rigidbody2D rigidbody;

	void Start() {
		rigidbody = GetComponent<Rigidbody2D> ();
	}

    void FixedUpdate() {
		var targetOffset = (target.position - transform.position).To2D ();
		var force = targetOffset * maxForce;
		rigidbody.AddForce (force);
    }
}
