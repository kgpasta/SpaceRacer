using UnityEngine;
using System.Collections;

public class MiniGamePoints : MonoBehaviour {

	int points = 0;
	public int goal = 4;
	public GameObject other;
	Player player;
//	Movement2 player2;
//	public float timer = 3.0f;

	void Start(){
		//player1 = (Movement) GameObject.Find ("Player1").GetComponent<Movement>();
//		player2 = (Movement2) GameObject.Find ("Player2").GetComponent<Movement2>();
		player = this.transform.parent.GetComponent<MiniGameTimer> ().mainGame.GetComponent<Player>();
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Trigger");
		points++;
		Debug.Log (points);
	}

	void Update() {
		if (points >= goal) {
			MiniGameReward();		
		}

//		if (timer > 0) {
//			timer -= Time.deltaTime;
//		}
//		if (timer <= 0) {
//			stopSpeedUp(player1);
//		}
	}

	void MiniGameReward(){
		//Debug.Log ("SpeedBoost");

		if (player) {
			Debug.Log(player.playerName);
			player.coeffSpeedUp = 200f;
			//stopSpeedUp(player);
		}

	}

	void stopSpeedUp(Player player){
		player.coeffSpeedUp = 100f;
	}


}
