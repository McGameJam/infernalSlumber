using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour {

		public Transform player;
		bool hasPlayer = false;
		bool beingCarried = false;

		void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject.CompareTag ("Player")) 
			    {
					hasPlayer = true;
				}
		}

		void OnTriggerExit2D(Collider2D other)
		{
			hasPlayer = false;
		}

		void FixedUpdate()
		{
			if(beingCarried)
			{
			if(Input.GetKeyDown(KeyCode.DownArrow))
				{
				transform.SetParent(null);
					beingCarried = false;
				}
			}
			else
			{
				if(hasPlayer && Input.GetKeyDown(KeyCode.DownArrow))
					{
					transform.SetParent (player);
				    beingCarried = true;
					}
			}
		}
	}
