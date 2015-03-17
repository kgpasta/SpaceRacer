using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public KeyCode up, right, left, down, upgrade;
    public Transform MissilePrefab;
    public Transform ShieldPrefab;
    Transform Missile;
    Transform Shield;
	private Player player;
	float boostTime = 50f;
	float boostTimer;
    float shieldTime = 15f;
    public bool shieldActive = false;
    bool hitByMissile = false;
    float missileTime = 1f;

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
                    player.BoostIcon.SetActive(false);
			    }

			    Debug.Log (boostTimer);

			    if (player.hasBoost == false){
				    boostTimer = boostTime;
			    }
            }
            else if (Input.GetKeyDown(upgrade) && player.hasMissile) {
                Missile = (Transform)Instantiate(MissilePrefab, this.transform.position, Quaternion.identity);
                string target = "player2";
                if (player.playerName == "Player2") {
                    target = "player1";
                }
                Missile.GetComponentInParent<Missile>().setTarget(GameObject.Find(target).transform);
                Missile.GetComponentInParent<Missile>().setOwner(this.transform);

                player.hasMissile = false;
                player.MissileIcon.SetActive(false);
            }
            else if (Input.GetKeyDown(upgrade) && player.hasShield)
            {
                Shield = (Transform)Instantiate(ShieldPrefab, this.transform.position, Quaternion.identity);
                Shield.SetParent(this.transform);
				Shield.transform.localScale = new Vector3(1f,1f);
                shieldActive = true;
                player.hasShield = false;
                player.ShieldIcon.SetActive(false);
            }

            if (shieldActive)
            {
                shieldTime -= Time.deltaTime;
                if (shieldTime <= 0)
                {
                    shieldActive = false;
                    Shield.gameObject.SetActive(false);
                    shieldTime = 1f;
                }
            }

		}

        if (hitByMissile)
        {
            missileTime -= Time.deltaTime;
            transform.Rotate(0f, 0f, missileTime / 1f * 90);
            if (missileTime <= 0)
            {
                player.isEnabled = true;
                hitByMissile = false;
                missileTime = 1f;
            }
        }
	}

	//Stops rotation on collision 
	void OnCollisionEnter2D(Collision2D collision) {
		rigidbody2D.angularVelocity = 0;
        if (!shieldActive)
        {
            rigidbody2D.drag = 1;
        }
	}
	
	void OnCollisionExit2D(Collision2D collision){
		rigidbody2D.angularVelocity = 3;
        rigidbody2D.drag = 0.5f;
	}

	public void setPlayer1Controls(){
		//Set Player 2 controls
		up = KeyCode.W;
		down = KeyCode.S;
		left = KeyCode.A;
		right = KeyCode.D;
		upgrade = KeyCode.E;
	}

    public void missileHit() {
        rigidbody2D.velocity = Vector2.zero;
        player.isEnabled = false;
        hitByMissile = true;
    }
}
