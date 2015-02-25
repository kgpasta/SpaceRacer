using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public KeyCode up, right, left, down;
	private Player player;

	// Use this for initialization
	void Start () {
		player = this.gameObject.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		// move left
		if (player.isEnabled){
			if (Input.GetKey (left)) {
				//Debug.Log ("Left Arrow has been hit");
				rigidbody2D.AddTorque(1f);
			}
			// move right
			if (Input.GetKey (right)) {
				//Debug.Log ("Right Arrow has been hit");
				rigidbody2D.AddTorque(-1f);
			}
			// move forward
			if (Input.GetKey (up)) {
				//Debug.Log ("Forward Arrow has been hit");
				rigidbody2D.AddForce(transform.up*player.coeffSpeedUp) ;		
			}
			// move backward
			if (Input.GetKey (down)) {
				//Debug.Log ("Backward Arrow has been hit");
				rigidbody2D.AddForce(-transform.up*100);		
			}
		}

	}

	//Stops rotation on collision 
	void OnCollisionEnter2D(Collision2D collision) {
		rigidbody2D.angularVelocity = 0;
	}
	
	void OnCollisionExit2D(Collision2D collision){
		rigidbody2D.angularVelocity = 3;
	}

	public void setPlayer2Controls(){
		//Set Player 2 controls
		up = KeyCode.W;
		down = KeyCode.S;
		left = KeyCode.A;
		right = KeyCode.D;
	}
}
