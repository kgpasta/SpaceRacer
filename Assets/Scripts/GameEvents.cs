using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameEvents : MonoBehaviour {

	public Transform playerPrefab;
	public Transform GametextPrefab;

	Transform player1;
	Transform player2;
	Transform gametext;

	// Use this for initialization
	void Start () {
		GameStart ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (IsGameOver ()) {
			player1.GetComponent<Player> ().isEnabled = false;
			player2.GetComponent<Player> ().isEnabled = false;
	
			gametext.gameObject.GetComponent<Text> ().text = "Game Over!";
	}
	}

	void GameStart(){
		//Time.timeScale = 0;
		player1 = (Transform) Instantiate (playerPrefab);
		player1.GetComponent<Player>().playerName = "Player1";


		player2 = (Transform) Instantiate (playerPrefab, new Vector3(-12.2f, -0.1f, -1f), Quaternion.identity);
		player2.GetComponent<Player>().playerName = "Player2";
		player2.GetComponent<Movement> ().setPlayer2Controls ();

		Transform MainCamera = player2.GetChild (0);
		Camera cam = MainCamera.GetComponent<Camera> ();
		cam.rect = new Rect (0f, 0f, 1f, 0.5f);

		Sprite[] Spaceships = Resources.LoadAll<Sprite> ("RetroSpaceship");
		player2.GetComponent<SpriteRenderer> ().sprite = Spaceships [7];

		gametext = (Transform)Instantiate (GametextPrefab);
		gametext.SetParent(GameObject.FindObjectOfType<Canvas> ().transform, false);

		StartCoroutine (Countdown ());
	}

	bool IsGameOver(){
		if(player1.GetComponent<Player>().laps >= 3 || player2.GetComponent<Player>().laps >= 3){
			return true;
		}
		return false;

	}

	IEnumerator Countdown () {

		int i = 3;
		while (i >0) {
			gametext.gameObject.GetComponent<Text> ().text = i.ToString();
			yield return new WaitForSeconds (1.0f);
			i--;
		}
		gametext.gameObject.GetComponent<Text> ().text = "GO";
		yield return new WaitForSeconds (0.5f);
		gametext.gameObject.GetComponent<Text> ().text = "";

		player1.GetComponent<Player> ().isEnabled = true;
		player2.GetComponent<Player> ().isEnabled = true;

		}
}
