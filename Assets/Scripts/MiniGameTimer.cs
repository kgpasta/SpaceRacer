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

    // Use this for initialization
    void Start()
    {
        player = mainGame.GetComponent<Player>();
        playerTimerText = (Transform)Instantiate(TimerTextPrefab);
        playerTimerText.SetParent(GameObject.FindObjectOfType<Canvas>().transform, false);

        introText = (Transform)Instantiate(IntroTextPrefab);
        introText.SetParent(GameObject.FindObjectOfType<Canvas>().transform, false);

        if (player.playerName == "Player1") {
			playerTimerText.gameObject.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.1f, 0.1f);
			playerTimerText.gameObject.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.1f, 0.1f);

			introText.gameObject.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.25f, 0.5f);
			introText.gameObject.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.25f, 0.5f);

		} 
		else {
			playerTimerText.gameObject.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.6f, 0.1f);
			playerTimerText.gameObject.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.6f, 0.1f);
			
			introText.gameObject.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.75f, 0.5f);
			introText.gameObject.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.75f, 0.5f);		
		}


        

        ballDropper = this.GetComponentInChildren<BallDropper>();

        StartCoroutine(DisplayIntroText());
    }


    // Update is called once per frame
    void Update()
    {

        playerTimerText.gameObject.GetComponent<Text>().text = "Time: " + timer;

        if (timer > 0f && gameEnabled)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0f)
        {

            restartMainGame(mainGame);

            // Get rid of minigame text
            Destroy(playerTimerText.gameObject);
            Destroy(gameObject.GetComponentInChildren<MiniGamePoints>().playerGoalText.gameObject);
            Destroy(gameObject.GetComponentInChildren<MiniGamePoints>().playerPointsText.gameObject);

        }

    }

    void restartMainGame(GameObject maingame)
    {
        this.GetComponentInChildren<MiniGamePoints>().rewardNotification();

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
        ballDropper.gameObject.SetActive(false);
        introText.gameObject.GetComponent<Text>().text = "Collect the objects!";
        yield return new WaitForSeconds(1.5f);

        gameEnabled = true;
        ballDropper.gameObject.SetActive(true);
    }
}
