using UnityEngine;
using System.Collections;

public class MiniGameTimer1 : MonoBehaviour {

	public float timer = 5.0f;
	float originalTimer;
	public GameObject mainGame1;
//	public GameObject mainGame2;

	
	// Use this for initialization
	void Start () {
		mainGame1 = GameObject.FindWithTag ("MainGame1");
//		mainGame2 = GameObject.FindWithTag ("MainGame2");
		originalTimer = timer;
	}

	void pauseMainGame (GameObject maingame) {
		maingame.SetActive (false);	
	}


	// Update is called once per frame
	void Update () {
		if (mainGame1.activeSelf != false) {
			pauseMainGame(mainGame1);
		}

		if (timer > 0) {
			timer -= Time.deltaTime;
		}
		if (timer <= 0) {
			restartMainGame(mainGame1);
		}
	}

	void restartMainGame (GameObject maingame)
	{
		if (maingame.activeSelf != true) {
			maingame.gameObject.SetActive(true);
		}

		timer = originalTimer;
		gameObject.SetActive(false);

	}
}
