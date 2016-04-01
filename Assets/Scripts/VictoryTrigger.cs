using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class VictoryTrigger : MonoBehaviour {

	public bool win = false;
	public static GameObject[] VictoryBeaconList;

	// Use this for initialization
	void Start() {
		GameObject.FindGameObjectsWithTag("victory");
	}

	// Update is called once per frame
	void Update() {

	}

	private void ActivateVictory()
	{
		foreach (GameObject cp in VictoryBeaconList)
		{
			cp.GetComponent<VictoryTrigger>().win = false;
		}
		win = true;
		SceneManager.LoadScene("victory");
		//delay and then load main menu
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player")) {
			ActivateVictory();
		}
	}
}
