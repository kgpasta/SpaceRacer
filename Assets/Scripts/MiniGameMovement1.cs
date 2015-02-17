using UnityEngine;
using System.Collections;

public class MiniGameMovement1 : MonoBehaviour {

	float maxSpeed = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 pos = transform.position;
		pos.x += Input.GetAxis ("Horizontal1") * maxSpeed * Time.deltaTime;
		transform.position = pos;
	}
}
