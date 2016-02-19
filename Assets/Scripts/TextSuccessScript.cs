using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextSuccessScript : MonoBehaviour {

	private Rigidbody2D aiai;

	void Start() {
		aiai = GetComponent<Rigidbody2D> ();

		Vector2 dytt = new Vector2 (Random.Range (-100.0f, 100.0f),
			               			Random.Range (-100.0f, 100.0f));
		
		aiai.AddTorque(Random.Range(-100.0f, 100.0f));
		aiai.AddForce (dytt, ForceMode2D.Impulse);
	}

	void Update() {
		transform.localScale += new Vector3 (0.1f, 0.0f, 0.3f);
	}
}
