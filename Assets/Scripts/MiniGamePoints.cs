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

	public GameObject highlight;
	GameObject popup; 

	int minigameType;


	void Start(){
		player = this.transform.parent.GetComponent<MiniGameTimer> ().mainGame.GetComponent<Player>();
		playerGoalText = (Transform) Instantiate (GoalTextPrefab);
		playerGoalText.SetParent (GameObject.FindObjectOfType<Canvas>().transform, false);
		playerPointsText = (Transform) Instantiate (PointsTextPrefab);
		playerPointsText.SetParent (GameObject.FindObjectOfType<Canvas>().transform, false);

		minigameType = gameObject.GetComponentInChildren<MiniGameMovement>().minigameType;


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
		if (minigameType == 1) {
			points++;	
			StartCoroutine(highlightPlayer());
		}

		if (minigameType == 2) {
			//death
			//exit minigame
			//notification that no reward was given
		}
		    
	}

	void Update() {

		playerPointsText.gameObject.GetComponent<Text> ().text = "Points: " + points;
		if (popup) {
			popup.transform.position = gameObject.transform.position;
		}
	}

	void MiniGameReward(){
		if (player) {
			upgrade(player, Random.value);
		}

	}

	void upgrade (Player player, float random) {
        Debug.Log(random);
        if (random <= 0.33f && !player.hasBoost) {
            player.hasBoost = true;
        }
        else if (random <= 0.66f && !player.hasMissile)
        {
            player.hasMissile = true;
        }
        else if(random <= 1f && !player.hasShield) {
            player.hasShield = true;
        }
	}

	public void rewardNotification (){
        if (points >= goal)
        {
            MiniGameReward();
        }

		playerRewardText = (Transform)Instantiate (RewardTextPrefab);
		playerRewardText.SetParent (GameObject.FindObjectOfType<Canvas>().transform, false);
        string button = "E";

		if (player.playerName == "Player2") {
			playerRewardText.gameObject.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.75f, 0.3f);
			playerRewardText.gameObject.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.75f, 0.3f);
            button = "Shift";
		} 
		else {
			playerRewardText.gameObject.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.25f, 0.3f);
			playerRewardText.gameObject.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.25f, 0.3f);
		}

		if (player.hasBoost) {
				playerRewardText.gameObject.GetComponent<Text> ().text = "Speed Boost Acquired! Hold " + button + " to boost!";
		}

        else if (player.hasMissile) {
            playerRewardText.gameObject.GetComponent<Text>().text = "Missile Acquired! Press " + button + " to Fire!";
        }
        else if (player.hasShield)
        {
            playerRewardText.gameObject.GetComponent<Text>().text = "Shield Acquired! Press " + button + " to Activate!";
        }

        else
        {
            playerRewardText.gameObject.GetComponent<Text>().color = Color.white;
            playerRewardText.gameObject.GetComponent<Text>().text = "No Power-ups Acquired";
        }

	}

	IEnumerator highlightPlayer(){
		popup = (GameObject)Instantiate (highlight, transform.position, Quaternion.identity);
		yield return new WaitForSeconds(0.2f);
		Destroy (popup);
	}






}
