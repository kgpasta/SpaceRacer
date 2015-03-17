using UnityEngine;
using System.Collections;

public class SpriteChanger : MonoBehaviour {

	public Sprite spriteIdle;
	public Sprite spriteForward;
	public Sprite spriteReverse;

	private SpriteRenderer spriteRenderer;
    Movement movement;


	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		if (spriteRenderer == null) {
			spriteRenderer.sprite = spriteIdle;				
		}
        movement = gameObject.GetComponentInParent<Movement>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(movement.up)) {
			spriteRenderer.sprite = spriteForward;	
		}

		if (Input.GetKey (movement.down)) {
			spriteRenderer.sprite = spriteReverse;	
		}

		if (Input.GetKeyUp (movement.up) || Input.GetKeyUp (movement.down)) {
			spriteRenderer.sprite = spriteIdle;	
		}

	}

    public void SetSprites(Sprite[] Spaceships)
    {
        //Player 2 sprites
        spriteIdle = Spaceships[7];
        spriteForward = Spaceships[4];
        spriteReverse = Spaceships[12];
    }
}
