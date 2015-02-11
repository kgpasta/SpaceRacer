using UnityEngine;
using System.Collections;

public class LapManager : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnTriggerEnter2D (Collider2D collider)
		{
				if (collider.gameObject.name.Equals ("Player1")) {
						if (collider.gameObject.GetComponent<Movement> ().distanceTraveled > Mathf.PI * 3) {
								collider.gameObject.GetComponent<Movement> ().laps++;
								collider.gameObject.GetComponent<Movement> ().distanceTraveled = 0;
						}
				} else if (collider.gameObject.name.Equals ("Player2")) {
						if (collider.gameObject.GetComponent<Movement2> ().distanceTraveled > Mathf.PI * 3) {
								collider.gameObject.GetComponent<Movement2> ().laps++;
								collider.gameObject.GetComponent<Movement2> ().distanceTraveled = 0;
						}
				}
		}
	}
	