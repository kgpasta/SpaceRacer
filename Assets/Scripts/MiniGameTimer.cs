using UnityEngine;
using System.Collections;

public class MiniGameTimer : MonoBehaviour {

	public float timer = 5.0f;
	public GameObject mainGame = null;
	
	// Use this for initialization
	void Start () {
//		mainGame2 = GameObject.FindWithTag ("MainGame2");
	}


	// Update is called once per frame
	void Update () {

//		if (mainGame != null && mainGame.activeSelf) {
//			pauseMainGame(mainGame);
//		}

		if (timer > 0) {
			timer -= Time.deltaTime;
		}
		if (timer <= 0) {
			restartMainGame(mainGame);
		}
	}

	void pauseMainGame (GameObject maingame) {
		maingame.SetActive (false);	
	}


	void restartMainGame (GameObject maingame)
	{
		if (maingame.activeSelf != true) {
			maingame.gameObject.SetActive(true);
		}

		Destroy (gameObject);

	}
}
