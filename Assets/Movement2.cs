using UnityEngine;
using System.Collections;

public class Movement2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Stops rotation on collision 
//	void OnCollisionEnter2D(Collider2D collision) {
//		rigidbody2D.angularVelocity = 0;
//		Debug.Log ("hi");
//	}

	// Update is called once per frame
	void Update () {

		// move left
		if (Input.GetKey (KeyCode.A)) {
			Debug.Log ("Left Arrow has been hit");
			rigidbody2D.AddTorque(1f);
		}
		// move right
		if (Input.GetKey (KeyCode.D)) {
			Debug.Log ("Right Arrow has been hit");
			rigidbody2D.AddTorque(-1f);
		}
		// move forward
		if (Input.GetKey (KeyCode.W)) {
			Debug.Log ("Forward Arrow has been hit");
			rigidbody2D.AddForce(transform.up*100);		
		}
		// move backward
		if (Input.GetKey (KeyCode.S)) {
			Debug.Log ("Backward Arrow has been hit");
			rigidbody2D.AddForce(-transform.up*100);		
		}
	}
//	void FixedUpdate(){
//		rigidbody2D.AddForce (Vector2.);
//	}

}
