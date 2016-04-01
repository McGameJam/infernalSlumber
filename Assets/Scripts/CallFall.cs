using UnityEngine;
using System.Collections;

public class CallFall : MonoBehaviour {
	public GameObject myWeapon;

	void onTriggerEnter2D()
	{
		myWeapon.GetComponent<Rigidbody2D> ().isKinematic = false;
	}

}
