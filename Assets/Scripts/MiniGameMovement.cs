using UnityEngine;
using System.Collections;

public class MiniGameMovement : MonoBehaviour {

	float maxSpeed = 5f;
	string axisname;

	// Use this for initialization
	void Start () {
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
		transform.position = pos;
	}
}
