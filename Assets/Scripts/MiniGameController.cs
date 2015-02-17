using UnityEngine;
using System.Collections;

public class MiniGameController : MonoBehaviour {


	public GameObject ball;

	// Use this for initialization
	void Start () {
		StartCoroutine (Spawn ());
	}
	
	IEnumerator Spawn() {
		while (true) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-2f, 2f), transform.position.y, 0.0f);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (ball, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (Random.Range (0.3f, 1f));
		}
	}

}
