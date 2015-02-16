using UnityEngine;
using System.Collections;

public class MiniGamePoints : MonoBehaviour {

	int points = 0;
	public int goal = 4;
	public GameObject other;



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
		Debug.Log ("SpeedBoost");

//		Movement playerScript = gameObject.GetComponent<Movement> ();
//		if (playerScript) {
//			playerScript.coeffSpeedUp = 200f;
//		}


	}

}
