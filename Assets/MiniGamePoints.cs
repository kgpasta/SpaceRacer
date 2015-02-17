using UnityEngine;
using System.Collections;

public class MiniGamePoints : MonoBehaviour {

	int points = 0;
	public int goal = 4;
	public GameObject other;
	Movement player1;
	Movement2 player2;

	void Start(){
		player1 = (Movement) GameObject.Find ("Player1").GetComponent<Movement>();
		player2 = (Movement2) GameObject.Find ("Player2").GetComponent<Movement2>();
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
	}

	void MiniGameReward(){
		//Debug.Log ("SpeedBoost");

		if (player1) {
			Debug.Log(player1.name);
			player1.coeffSpeedUp = 200f;
		}




	}

}
