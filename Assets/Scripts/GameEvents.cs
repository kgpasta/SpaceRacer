using UnityEngine;
using System.Collections;

public class GameEvents : MonoBehaviour {

	public Transform playerPrefab;
	Transform player1;
	Transform player2;

	// Use this for initialization
	void Start () {
		GameStart ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GameStart(){
		//Time.timeScale = 0;
		player1 = (Transform) Instantiate (playerPrefab);
		player1.GetComponent<Player>().playerName = "Player1";


		player2 = (Transform) Instantiate (playerPrefab, new Vector3(-3.45f, -0.1f, -1f), Quaternion.identity);
		player2.GetComponent<Player>().playerName = "Player2";
		player2.GetComponent<Movement> ().setPlayer2Controls ();
		Transform MainCamera = player2.GetChild (0);
		Camera cam = MainCamera.GetComponent<Camera> ();
		cam.rect = new Rect (0f, 0f, 1f, 0.5f);

		Sprite[] Spaceships = Resources.LoadAll<Sprite> ("RetroSpaceship");
		player2.GetComponent<SpriteRenderer> ().sprite = Spaceships [7];

		}
}
