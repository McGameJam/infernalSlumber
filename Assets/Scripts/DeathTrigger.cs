using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class DeathTrigger : MonoBehaviour {

    public int count=0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{

        if (count == 3)
        {
            SceneManager.LoadScene("GameOver");
        }
        else if (other.gameObject.CompareTag("Player"))
        {

            count++;

            other.transform.position=CheckPoint.GetActiveCheckPointPosition();


            // Application.LoadLevel(Application.loadedLevel);
        }
        else if (other.gameObject.CompareTag("Sleepwalker"))
        {
            SceneManager.LoadScene("GameOver");
            SceneManager.LoadScene("Menu");
        }

        else
        {
            Destroy(other.gameObject);
        }
	}
}
