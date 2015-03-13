using UnityEngine;
using System.Collections;

public class MiniGameMovement : MonoBehaviour {

	float maxSpeed = 5f;
	string axisname;

	Camera cam;
	float height;
	float width;
	
	// Use this for initialization
	void Start () {
		cam = gameObject.transform.parent.GetComponentInChildren<Camera> ().camera;
		height = cam.orthographicSize*2f;
		width = cam.aspect*height;
		axisname = this.transform.parent.GetComponent<MiniGameTimer> ().mainGame.GetComponent<Player> ().playerName;
		if (axisname == "Player1") {
			axisname = "Horizontal1";
		} else {
			axisname = "Horizontal2";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 pos = transform.position;
		pos.x += Input.GetAxis (axisname) * maxSpeed * Time.deltaTime;

		if (pos.x > width/2){
			pos.x = width/2;
		}

		if (pos.x < -width/2){
			pos.x = -width/2;
		}
		transform.position = pos;
	}
}
