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
		public GameObject mainGame = null; 
		public GameObject player1;
		
		public bool isWinner = false;

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
		/// temporary change .1 to 3
			if (collider.gameObject.GetComponent<Player> ().distanceTraveled > collider.gameObject.GetComponent<Player> ().lapTriggerDistance) {
					Player player = collider.gameObject.GetComponent<Player> ();
					player.laps++;
					player.distanceTraveled = 0;
					Transform playerText = Player1Text;
					if(player.playerName == "Player2"){
						playerText = Player2Text;
					}
					playerText.gameObject.GetComponent<Text> ().text = "Laps: " + player.laps;
				if (player.laps >= 3 && !isWinner){
					// decide the winner
					isWinner = true;
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
			GameObject minigame;

			if(player.GetComponent<Player> ().playerName == "Player2"){
				minigame = (GameObject) Instantiate (minigamePrefab, new Vector3(0f, -300f, 0f), Quaternion.identity);
			}
			else {
				minigame = (GameObject) Instantiate (minigamePrefab);
			}	

			minigame.GetComponent<MiniGameTimer> ().setPlayer (player);

			
		}
			
}