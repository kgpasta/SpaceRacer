using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MiniGameTimer : MonoBehaviour
{

    public float timer;
    public GameObject mainGame = null;

    Player player;

    public Transform TimerTextPrefab;
    Transform playerTimerText;

    public Transform IntroTextPrefab;
    Transform introText;
    bool gameEnabled = false;

    BallDropper ballDropper;

	Camera cam;

	int minigameType;

    // Use this for initialization
    void Start()
    {
		cam = gameObject.GetComponentInChildren<Camera> ().camera;
		player = mainGame.GetComponent<Player>();
        playerTimerText = (Transform)Instantiate(TimerTextPrefab);
        playerTimerText.SetParent(GameObject.FindObjectOfType<Canvas>().transform, false);

        introText = (Transform)Instantiate(IntroTextPrefab);
        introText.SetParent(GameObject.FindObjectOfType<Canvas>().transform, false);

		minigameType = gameObject.GetComponentInChildren<MiniGameMovement>().minigameType;
        
		if (player.playerName == "Player1") {
			playerTimerText.gameObject.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.25f, 1f);
			playerTimerText.gameObject.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.25f, 1f);

			introText.gameObject.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.25f, 0.5f);
			introText.gameObject.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.25f, 0.5f);

		} 
		else {
			playerTimerText.gameObject.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.75f, 1f);
			playerTimerText.gameObject.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.75f, 1f);
			
			introText.gameObject.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.75f, 0.5f);
			introText.gameObject.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.75f, 0.5f);		

			Color camcolor = new Color (0f/255f, 220f/255f, 251f/255f, 5f/255f);
			cam.backgroundColor = camcolor;
		}

			ballDropper = this.GetComponentInChildren<BallDropper>();		
        

        StartCoroutine(DisplayIntroText());
    }


    // Update is called once per frame
    void Update()
    {
		string time = timer.ToString ("0.00");

        playerTimerText.gameObject.GetComponent<Text>().text = time + "s";

        if (timer > 0f && gameEnabled)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0f)
        {
            restartMainGame(mainGame);
        }
    }

    public void restartMainGame(GameObject maingame)
    {
        this.GetComponentInChildren<MiniGamePoints>().rewardNotification();

		Destroy(playerTimerText.gameObject);
		Destroy(gameObject.GetComponentInChildren<MiniGamePoints>().playerGoalText.gameObject);
		Destroy(gameObject.GetComponentInChildren<MiniGamePoints>().playerPointsText.gameObject);

        if (maingame.activeSelf != true)
        {
            maingame.gameObject.SetActive(true);
        }

        Destroy(gameObject);
    }

    public void setPlayer(GameObject player)
    {
        mainGame = player;

        //Reset Camera
        Rect r = player.transform.GetChild(0).GetComponent<Camera>().rect;
        this.GetComponentInChildren<Camera>().rect = new Rect(r.x, r.y, r.width, r.height);
        player.SetActive(false);

        //Set Sprite
        this.GetComponentInChildren<SpriteRenderer>().sprite = player.GetComponent<SpriteRenderer>().sprite;
    }

    IEnumerator DisplayIntroText()
    {
		if (minigameType == 1) {
			ballDropper.gameObject.SetActive(false);
			introText.gameObject.GetComponent<Text>().text = "Collect " + gameObject.GetComponentInChildren<MiniGamePoints>().goal.ToString() + " falling objects!";
			yield return new WaitForSeconds(2f);
			
			gameEnabled = true;
			ballDropper.gameObject.SetActive(true);
		}

		if (minigameType == 2) {
			introText.gameObject.GetComponent<Text>().text = "Shoot the asteroids!";
			yield return new WaitForSeconds(2f);
			
			gameEnabled = true;
		}
       
    }
}
