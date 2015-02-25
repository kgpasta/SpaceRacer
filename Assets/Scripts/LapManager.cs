using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LapManager : MonoBehaviour
{

		public Transform Player1TextPrefab;
		public Transform Player2TextPrefab;
		
		Transform Player1Text;
		Transform Player2Text;

		public GameObject minigamePrefab;

		
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
		}

		void OnTriggerEnter2D (Collider2D collider)
		{
			if (collider.gameObject.GetComponent<Player> ().distanceTraveled > Mathf.PI * 3) {
				Player player = collider.gameObject.GetComponent<Player> ();
				player.laps++;
				player.distanceTraveled = 0;
				Transform playerText = Player1Text;
				if(player.playerName == "Player2"){
					playerText = Player2Text;
				}
				playerText.gameObject.GetComponent<Text> ().text = "Laps: " + player.laps;
				if (player.laps >= 3){
					// decide the winner
					playerText.gameObject.GetComponent<Text>().text = "WINNER";
				}
				else{
					startMiniGame (minigamePrefab, collider.gameObject);
				}	
			}
		}

		

		void startMiniGame (GameObject minigamePrefab, GameObject player)
		{
//			minigame.SetActive(true);
			GameObject minigame = (GameObject) Instantiate (minigamePrefab);
			minigame.GetComponent<MiniGameTimer> ().setPlayer (player);

			
		}
			
}