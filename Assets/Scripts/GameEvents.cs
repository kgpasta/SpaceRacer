using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameEvents : MonoBehaviour {

	public Transform playerPrefab;
	public Transform GametextPrefab;

	Transform player1;
	Transform player2;
	public Transform gametext;

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
		player1.name = "player1";
		player1.GetComponent<Player>().playerName = "Player1";
		player1.GetComponent<Movement> ().setPlayer1Controls ();

		player2 = (Transform) Instantiate (playerPrefab, new Vector3(-19.25f, -0.2f, -1f), Quaternion.identity);
        player2.Rotate(0f, 0f, 348f);
        player2.localScale = new Vector3(0.2f, -0.2f, 0.2f);
		player2.GetComponent<Player>().playerName = "Player2";
        
        //Set player2icon
        player2.GetComponent<Player>().icon.GetComponent<RectTransform>().anchorMin = new Vector2(1, 1);
        player2.GetComponent<Player>().icon.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);

		Transform MainCamera = player2.GetChild (0);
		Camera cam = MainCamera.GetComponent<Camera> ();

		// view point rect for camera 2
		cam.rect = new Rect (0.5f, 0f, 0.5f, 1f);

		Sprite[] Spaceships = Resources.LoadAll<Sprite> ("RetroSpaceship");
		player2.GetComponent<SpriteRenderer> ().sprite = Spaceships [7];

        player2.GetComponent<SpriteChanger>().SetSprites(Spaceships);

		gametext = (Transform)Instantiate (GametextPrefab);
		gametext.SetParent(GameObject.FindObjectOfType<Canvas> ().transform, false);

		gametext.gameObject.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.5f, 0.5f);
		gametext.gameObject.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.5f, 0.5f);

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
