using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextFailScript : MonoBehaviour {

	private Rigidbody2D aiai;

	void Start() {
		aiai = GetComponent<Rigidbody2D> ();

		Vector2 dytt = new Vector2 (Random.Range (-300.0f, 300.0f),
			               			Random.Range (-300.0f, 300.0f));
		
		aiai.AddTorque(Random.Range(-300.0f, 300.0f));
		aiai.AddForce (dytt, ForceMode2D.Impulse);
	}
}
