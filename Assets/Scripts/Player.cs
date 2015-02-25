using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public string playerName;
	public float distanceTraveled;
	private Vector3 previousPosition;
	public int laps;
	public float coeffSpeedUp = 100f;
	public bool isEnabled = false;
	
	// Use this for initialization
	void Start () {
		previousPosition = this.transform.position;
		laps = 0;
		distanceTraveled = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Update distance traveled
		distanceTraveled += Vector3.Distance(this.transform.position, previousPosition);
		previousPosition = this.transform.position;
	}
}
