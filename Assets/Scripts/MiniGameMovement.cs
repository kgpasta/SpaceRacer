using UnityEngine;
using System.Collections;

public class MiniGameMovement : MonoBehaviour {

	public int minigameType;

	float maxSpeed = 5f;
	float rotSpeed = 180f;

	string xAxisName;
	string yAxisName;
	string playerName;

	float camCenterPos; 
	Camera cam;
	float height;
	float width;
	
	// Use this for initialization
	void Start () {
		cam = gameObject.transform.parent.GetComponentInChildren<Camera> ().camera;
		height = cam.orthographicSize*2f;
		width = cam.aspect*height;
		playerName = this.transform.parent.GetComponent<MiniGameTimer> ().mainGame.GetComponent<Player> ().playerName;
		camCenterPos = this.transform.parent.position.y;

		if (playerName == "Player1") {
			xAxisName = "Horizontal1";
			yAxisName = "Vertical1";
		} 

		else {
			xAxisName = "Horizontal2";
			yAxisName = "Vertical2";
		}

	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 pos = transform.position;

		if (minigameType == 1) {
			pos.x += Input.GetAxis (xAxisName) * maxSpeed * Time.deltaTime;
		}

		if (minigameType == 2) {

			maxSpeed = 3f;

			Quaternion rot = transform.rotation;
			float z = rot.eulerAngles.z;
			z -= Input.GetAxis (xAxisName) * rotSpeed * Time.deltaTime;
			rot = Quaternion.Euler(0,0,z);
			transform.rotation = rot;

			Vector3 velocity = new Vector3(0, Input.GetAxis(yAxisName) * maxSpeed * Time.deltaTime, 0);
			pos += rot * velocity;
		}

		if (pos.x > width/2){
			pos.x = width/2;
		}

		if (pos.x < -width/2){
			pos.x = -width/2;
		}

		if (pos.y > camCenterPos + height/2){
			pos.y = camCenterPos + height/2;
		}

		if (pos.y < camCenterPos - height/2){
			pos.y = camCenterPos - height/2;
		}


		transform.position = pos;
	
	}
}
