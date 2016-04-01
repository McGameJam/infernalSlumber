using UnityEngine;
using System.Collections;

public class Fall : MonoBehaviour {

	private bool shouldFall;
	private Rigidbody2D rb2d;
	// Use this for initialization
	void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
		if (shouldFall) {
			rb2d.isKinematic = false;
		}
	}

	public void SetFall()
	{
		shouldFall = true;
	}
}
