using UnityEngine;
using System.Collections;

public class SpriteChanger : MonoBehaviour {

	public Sprite spriteIdle;
	public Sprite spriteForward;
	public Sprite spriteReverse;

	private SpriteRenderer spriteRenderer; 


	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		if (spriteRenderer == null) {
			spriteRenderer.sprite = spriteIdle;				
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.UpArrow)) {
			spriteRenderer.sprite = spriteForward;	
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			spriteRenderer.sprite = spriteReverse;	
		}

		if (Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp (KeyCode.DownArrow)) {
			spriteRenderer.sprite = spriteIdle;	
		}

	}
}
