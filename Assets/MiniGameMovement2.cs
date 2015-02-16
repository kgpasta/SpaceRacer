using UnityEngine;
using System.Collections;

public class MiniGameMovement2 : MonoBehaviour {

	float maxSpeed = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 pos = transform.position;
		pos.x += Input.GetAxis ("Horizontal2") * maxSpeed * Time.deltaTime;
		transform.position = pos;
	}
}
