using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject enemy;
	Camera cam;
	float height;
	float width;
	float camCenterPos; 

	
	// Use this for initialization
	void Start () {
		cam = gameObject.transform.parent.GetComponentInChildren<Camera> ().camera;
		StartCoroutine (Spawn ());
		height = cam.orthographicSize*2f;
		width = cam.aspect*height;
		camCenterPos = this.transform.parent.position.y;
		Debug.Log (cam);
		Debug.Log (height);
		Debug.Log (width);
	}
	
	IEnumerator Spawn() {
		while (true) {
			Vector3 spawnPosition = new Vector3 (transform.position.x + Random.Range (-width, width), transform.position.y + Random.Range(-height/2, height/2), 0.0f);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (enemy, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (Random.Range (0.5f, 1f));
			
		}
	}
}