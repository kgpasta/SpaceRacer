using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MiniGamePoints : MonoBehaviour {

	public int points = 0;
	public int goal;

	Player player;

	public Transform GoalTextPrefab;
	public Transform PointsTextPrefab;
	public Transform RewardTextPrefab;

	public Transform playerGoalText;
	public Transform playerPointsText;
	public Transform playerRewardText;





	void Start(){
		player = this.transform.parent.GetComponent<MiniGameTimer> ().mainGame.GetComponent<Player>();
		playerGoalText = (Transform) Instantiate (GoalTextPrefab);
		playerGoalText.SetParent (GameObject.FindObjectOfType<Canvas>().transform, false);
		playerPointsText = (Transform) Instantiate (PointsTextPrefab);
		playerPointsText.SetParent (GameObject.FindObjectOfType<Canvas>().transform, false);



		if(player.playerName == "Player2"){
			playerGoalText.gameObject.GetComponent<RectTransform> ().anchorMin = new Vector2 (1f, 1f);
			playerGoalText.gameObject.GetComponent<RectTransform> ().anchorMax = new Vector2 (1f, 1f);

			playerPointsText.gameObject.GetComponent<RectTransform> ().anchorMin = new Vector2 (1f, 1f);
			playerPointsText.gameObject.GetComponent<RectTransform> ().anchorMax = new Vector2 (1f, 1f);
		}

		else {
			playerGoalText.gameObject.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.5f, 1f);
			playerGoalText.gameObject.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.5f, 1f);

			playerPointsText.gameObject.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.5f, 1f);
			playerPointsText.gameObject.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.5f, 1f);
		}

		playerGoalText.gameObject.GetComponent<Text> ().text = "Goal: " + goal;
		playerPointsText.gameObject.GetComponent<Text> ().text = "Points: " + points;
	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		points++;
	}

	void Update() {


		if (points >= goal) {
			MiniGameReward();		
		}

		playerPointsText.gameObject.GetComponent<Text> ().text = "Points: " + points;
	}

	void MiniGameReward(){
		if (player) {
			speedBoost(player);
		}

	}

	void speedBoost (Player player) {
		player.hasBoost = true;
	}

	public void rewardNotification (){

		playerRewardText = (Transform)Instantiate (RewardTextPrefab);
		playerRewardText.SetParent (GameObject.FindObjectOfType<Canvas>().transform, false);

		if (player.playerName == "Player2") {
			playerRewardText.gameObject.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.75f, 0.3f);
			playerRewardText.gameObject.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.75f, 0.3f);
		} 
		else {
			playerRewardText.gameObject.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.25f, 0.3f);
			playerRewardText.gameObject.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.25f, 0.3f);
		}

		if (player.hasBoost) {
			playerRewardText.gameObject.GetComponent<Text> ().text = "Speed Boost Acquired!";
		}

		else {
			playerRewardText.gameObject.GetComponent<Text> ().color = Color.white;
			playerRewardText.gameObject.GetComponent<Text> ().text = "No Power-ups Acquired";
		}

	}




}
