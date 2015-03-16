using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {
    private Transform target;
    private Transform owner;
    private float range;

	// Use this for initialization
	void Start () {
        range = 5f;
        rigidbody2D.velocity = Vector2.up * 3f;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 toTarget = target.position - transform.position;
        rigidbody2D.velocity = toTarget.normalized * 3f;

        range -= Time.deltaTime;
        if (range <= 0f) {
            Destroy(transform.gameObject);
        }
	}

    public void setTarget(Transform player) {
        target = player;
    }

    public void setOwner(Transform player) {
        owner = player;
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.transform != owner && other.transform != GameObject.Find("Lap Line").transform){
            if (other.GetComponent<Rigidbody2D>() != null)
            {
                other.rigidbody2D.velocity = Vector2.zero;
            }
            Destroy(transform.gameObject);
        }
        
    }
}
