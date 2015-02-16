using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LapManager : MonoBehaviour
{

		public Transform Player1TextPrefab;
		public Transform Player2TextPrefab;
		Transform Player1Text;
		Transform Player2Text;

		// Use this for initialization
		void Start ()
		{
			Player1Text = (Transform) Instantiate (Player1TextPrefab);
			Player2Text = (Transform) Instantiate (Player2TextPrefab);
			Player1Text.SetParent (GameObject.FindObjectOfType<Canvas>().transform, false);
			Player2Text.SetParent (GameObject.FindObjectOfType<Canvas>().transform, false);
			Player1Text.gameObject.GetComponent<Text> ().text = "Laps: 0";
			Player2Text.gameObject.GetComponent<Text> ().text = "Laps: 0";
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnTriggerEnter2D (Collider2D collider)
		{
				if (collider.gameObject.name.Equals ("Player1")) {
						if (collider.gameObject.GetComponent<Movement> ().distanceTraveled > Mathf.PI * 3) {
								int laps = collider.gameObject.GetComponent<Movement> ().laps;
								laps++;
								collider.gameObject.GetComponent<Movement> ().distanceTraveled = 0;
								Player1Text.gameObject.GetComponent<Text> ().text = "Laps: " + laps;
						}
				} else if (collider.gameObject.name.Equals ("Player2")) {
						if (collider.gameObject.GetComponent<Movement2> ().distanceTraveled > Mathf.PI * 3) {
								int laps = collider.gameObject.GetComponent<Movement2> ().laps;
								laps++;
								collider.gameObject.GetComponent<Movement2> ().distanceTraveled = 0;
								Player2Text.gameObject.GetComponent<Text> ().text = "Laps: " + laps;
						}
				}
		}
	}
	