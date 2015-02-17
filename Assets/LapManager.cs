using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LapManager : MonoBehaviour
{

		public Transform Player1TextPrefab;
		public Transform Player2TextPrefab;
		Transform Player1Text;
		Transform Player2Text;

		public GameObject minigame1;
		public GameObject minigame2;

		
		// Use this for initialization
		void Start ()
		{
			Player1Text = (Transform) Instantiate (Player1TextPrefab);
			Player2Text = (Transform) Instantiate (Player2TextPrefab);
			Player1Text.SetParent (GameObject.FindObjectOfType<Canvas>().transform, false);
			Player2Text.SetParent (GameObject.FindObjectOfType<Canvas>().transform, false);
			Player1Text.gameObject.GetComponent<Text> ().text = "Laps: 0";
			Player2Text.gameObject.GetComponent<Text> ().text = "Laps: 0";
			
//			minigame1 = GameObject.FindWithTag ("MiniGame1");
//			minigame1.SetActive (false);
//			minigame2 = GameObject.FindWithTag ("MiniGame2");
//			minigame2.SetActive (false);


		}
	
		// Update is called once per frame
		void Update ()
		{
			if (Input.GetKey (KeyCode.M)) {
				startMiniGame (minigame1);
			}
		}

		void OnTriggerEnter2D (Collider2D collider)
		{
				if (collider.gameObject.name.Equals ("Player1")) {
						if (collider.gameObject.GetComponent<Movement> ().distanceTraveled > Mathf.PI * 3) {
								int lapsPlayer1 = collider.gameObject.GetComponent<Movement> ().laps;
								collider.gameObject.GetComponent<Movement> ().laps++;
								lapsPlayer1++;
								collider.gameObject.GetComponent<Movement> ().distanceTraveled = 0;
								Player1Text.gameObject.GetComponent<Text> ().text = "Laps: " + lapsPlayer1;
								startMiniGame (minigame1);
						}
				} else if (collider.gameObject.name.Equals ("Player2")) {
						if (collider.gameObject.GetComponent<Movement2> ().distanceTraveled > Mathf.PI * 3) {
								int lapsPlayer2 = collider.gameObject.GetComponent<Movement2> ().laps;
								collider.gameObject.GetComponent<Movement2> ().laps++;
								lapsPlayer2++;
								collider.gameObject.GetComponent<Movement2> ().distanceTraveled = 0;
								Player2Text.gameObject.GetComponent<Text> ().text = "Laps: " + lapsPlayer2;
								startMiniGame (minigame2);
						}
				}

		}

		

		void startMiniGame (GameObject minigame)
		{
//			minigame.SetActive(true);
			Instantiate (minigame);

		}
			
}