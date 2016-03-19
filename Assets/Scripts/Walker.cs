using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Walker : MonoBehaviour {
	public float walkSpeed = 2.0f;
	public float moveForce = 3f;
	public int startHealth = 10;
	public int currentHealth;
	public Slider healthSlider;

	private Rigidbody2D rb2d;


	void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();
		currentHealth = startHealth;
	}

	void FixedUpdate ()
	{
		if (rb2d.velocity.x < walkSpeed) {
			rb2d.AddForce (Vector2.right * moveForce);
		}

		if (Mathf.Abs (rb2d.velocity.x) > walkSpeed) {
			rb2d.velocity = new Vector2 (Mathf.Sign(rb2d.velocity.x) * walkSpeed, rb2d.velocity.y);
		}
			
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Obstacle")) 
		{
			moveForce = 6f;
		}
		if (other.gameObject.CompareTag ("Danger")) 
		{
			TakeDamage (1);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Obstacle")) 
		{
			moveForce = 1f;
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
