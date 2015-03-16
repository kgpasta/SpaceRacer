using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject enemy;
	Camera cam;
	float height;
	float width;
	
	// Use this for initialization
	void Start () {
		cam = gameObject.transform.parent.GetComponentInChildren<Camera> ().camera;
		StartCoroutine (Spawn ());
		height = cam.orthographicSize*2f;
		width = cam.aspect*height;
	}
	
	IEnumerator Spawn() {
		while (true) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-width/2, width/2), Random.Range (-height/2, height/2), 0.0f);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (enemy, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (Random.Range (0.5f, 1f));
			
		}
	}
}