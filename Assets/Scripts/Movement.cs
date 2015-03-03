using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public KeyCode up, right, left, down, upgrade;
	private Player player;
	float boostTime = 50f;
	float boostTimer;

	// Use this for initialization
	void Start () {
		player = this.gameObject.GetComponent<Player>();
		boostTimer = boostTime;
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
			rigidbody2D.AddForce(transform.up * player.acceleration) ;		
		}
		// move backward
		if (Input.GetKey (down)) {
			//Debug.Log ("Backward Arrow has been hit");
			rigidbody2D.AddForce(-transform.up * player.deceleration);		
		}

		if (Input.GetKey (upgrade) && player.hasBoost == true) {
			rigidbody2D.AddForce(transform.up * player.speedBoost);
			boostTimer -= 1f;

			if (boostTimer <= 0) {
//				player.speedBoost = 1f;
				player.hasBoost = false;
			}

			Debug.Log (boostTimer);

			if (player.hasBoost == false){
				boostTimer = boostTime;
			}

		}
		}


	}

	//Stops rotation on collision 
	void OnCollisionEnter2D(Collision2D collision) {
		rigidbody2D.angularVelocity = 0;
        rigidbody2D.drag = 1;
	}
	
	void OnCollisionExit2D(Collision2D collision){
		rigidbody2D.angularVelocity = 3;
        rigidbody2D.drag = 0.5f;
	}

	public void setPlayer2Controls(){
		//Set Player 2 controls
		up = KeyCode.W;
		down = KeyCode.S;
		left = KeyCode.A;
		right = KeyCode.D;
		upgrade = KeyCode.E;
	}
}
