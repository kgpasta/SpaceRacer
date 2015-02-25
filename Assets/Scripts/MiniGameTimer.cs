using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MiniGameTimer : MonoBehaviour {

	public float timer;
	public GameObject mainGame = null;

	Player player;

	public Transform TimerTextPrefab;
	Transform playerTimerText;


	// Use this for initialization
	void Start () {

		player = mainGame.GetComponent<Player> ();
		playerTimerText = (Transform)Instantiate (TimerTextPrefab);
		playerTimerText.SetParent (GameObject.FindObjectOfType<Canvas>().transform, false);

		
		if(player.playerName == "Player2"){
			playerTimerText.gameObject.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.5f, 0.5f);
			playerTimerText.gameObject.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.5f, 0.5f);
		}
	}


	// Update is called once per frame
	void Update () {

		playerTimerText.gameObject.GetComponent<Text> ().text = "Time: " + timer;

		if (timer > 0f) {
			timer -= Time.deltaTime;
		}
		if (timer <= 0f) {

			restartMainGame(mainGame);

			// Get rid of minigame text
			Destroy(playerTimerText.gameObject);
			Destroy(gameObject.GetComponentInChildren<MiniGamePoints>().playerGoalText.gameObject);
			Destroy(gameObject.GetComponentInChildren<MiniGamePoints>().playerPointsText.gameObject);
			
		}

	}

	void restartMainGame (GameObject maingame)
	{
		this.GetComponentInChildren<MiniGamePoints> ().rewardNotification ();

		if (maingame.activeSelf != true) {
			maingame.gameObject.SetActive(true);
		}

		Destroy (gameObject);
	}

	public void setPlayer(GameObject player){
		mainGame = player;

		//Reset Camera
		Rect r = player.transform.GetChild(0).GetComponent<Camera> ().rect;
		this.GetComponentInChildren<Camera>().rect = new Rect (r.x, r.y, r.width, r.height);
		player.SetActive (false);

		//Set Sprite
		this.GetComponentInChildren<SpriteRenderer> ().sprite = player.GetComponent<SpriteRenderer> ().sprite;
	}
}
