using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public string playerName;
	public float distanceTraveled;
	private Vector3 previousPosition;
	public int laps;
	public float acceleration;
	public float deceleration;
	public bool hasBoost = false;
	public float speedBoost;
	public float coeffSpeedUp = 100f;
	public bool isEnabled = false;
	
	public GameObject icon;

	// Use this for initialization
	void Start () {
		previousPosition = this.transform.position;
		laps = 0;
		distanceTraveled = 0;
		icon = (GameObject) Instantiate (icon);
		icon.transform.SetParent(GameObject.FindObjectOfType<Canvas>().transform, false);
        icon.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		//Update distance traveled
		distanceTraveled += Vector3.Distance(this.transform.position, previousPosition);
		previousPosition = this.transform.position;
		displayRewardIcon ();

	}

    void displayRewardIcon()
    {
        if (hasBoost)
        {
            icon.SetActive(true);
        }

    }
}
