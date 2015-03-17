using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public string playerName;
	public float distanceTraveled;
	public float lapTriggerDistance;
	private Vector3 previousPosition;
	public int laps;
	public float acceleration;
	public float deceleration;
	public bool hasBoost = false;
	public float speedBoost;
	public float coeffSpeedUp = 100f;
    public bool hasMissile = false;
    public bool hasShield = false;
	public bool isEnabled = false;
	
	public GameObject BoostIconPfab;
    public GameObject MissileIconPfab;
    public GameObject ShieldIconPfab;
    public GameObject BoostIcon;
    public GameObject MissileIcon;
    public GameObject ShieldIcon;
	public float time = 0f;

	// Use this for initialization
	void Start () {
		previousPosition = this.transform.position;
		laps = 0;
		distanceTraveled = 0;
		BoostIcon = (GameObject) Instantiate (BoostIconPfab);
		BoostIcon.transform.SetParent(GameObject.FindObjectOfType<Canvas>().transform, false);
        BoostIcon.SetActive(false);

        MissileIcon = (GameObject)Instantiate(MissileIconPfab);
        MissileIcon.transform.SetParent(GameObject.FindObjectOfType<Canvas>().transform, false);
        MissileIcon.SetActive(false);

        ShieldIcon = (GameObject)Instantiate(ShieldIconPfab);
        ShieldIcon.transform.SetParent(GameObject.FindObjectOfType<Canvas>().transform, false);
        ShieldIcon.SetActive(false);

        //Set player2icons
        if (playerName == "Player2")
        {
            BoostIcon.GetComponent<RectTransform>().anchorMin = new Vector2(1, 1);
            BoostIcon.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            MissileIcon.GetComponent<RectTransform>().anchorMin = new Vector2(1, 1);
            MissileIcon.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            ShieldIcon.GetComponent<RectTransform>().anchorMin = new Vector2(1, 1);
            ShieldIcon.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        }
	}
	
	// Update is called once per frame
	void Update () {
		//Update distance traveled
		distanceTraveled += Vector3.Distance(this.transform.position, previousPosition);
		previousPosition = this.transform.position;
		displayRewardIcon ();
		if (isEnabled) {
			time += Time.deltaTime;
		}

	}

    void displayRewardIcon()
    {
        if (hasBoost)
        {
            BoostIcon.SetActive(true);
        }
        if (hasMissile) {
            MissileIcon.SetActive(true);
        }
        if (hasShield)
        {
            ShieldIcon.SetActive(true);
        }

    }
}
