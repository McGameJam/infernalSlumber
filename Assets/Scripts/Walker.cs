using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Walker : MonoBehaviour {
	public float walkSpeed = 2.0f;
	public float moveForce = 3f;
	public int startHealth = 10;
	public int currentHealth;
	public Slider healthSlider;
	public Transform target;
	public int rotationSpeed;

	private Rigidbody2D rb2d;
	private Transform myTransform;

	void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();
		currentHealth = startHealth;
		myTransform = transform;
	}

	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag ("victory");
		target = go.transform;
	}

	void Update ()
	{
		Vector3 dir = target.position - myTransform.position;
		dir.z = 0.0f;

		if (dir != Vector3.zero) 
		{
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation,Quaternion.FromToRotation(Vector3.right, dir), rotationSpeed * Time.deltaTime);
		}

		myTransform.position += (target.position - myTransform.position).normalized * walkSpeed * Time.deltaTime;

		/*if (Mathf.Abs (rb2d.velocity.x) > walkSpeed) {
			rb2d.velocity = new Vector2 (Mathf.Sign(rb2d.velocity.x) * walkSpeed, rb2d.velocity.y);
		}*/
        //load the game over if no more health
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
            SceneManager.LoadScene("Menu");
           
        }
			
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Obstacle")) 
		{
            TakeDamage(3);
        }
		if (other.gameObject.CompareTag ("Danger")) 
		{
            currentHealth = 0;
		}
		if (other.gameObject.CompareTag ("Ramp")) 
		{
			walkSpeed = 7f;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Obstacle")) 
		{
			walkSpeed = 1f;
		}
	}
	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		healthSlider.value = currentHealth;
		if (currentHealth <= 0) {
			Destroy (gameObject);
		}
	}
}
