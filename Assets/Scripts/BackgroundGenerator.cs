using UnityEngine;
using System.Collections;

public class BackgroundGenerator : MonoBehaviour {
    const int WorldSize = 20;
    public GameObject BackgroundTile;

	// Use this for initialization
	void Start () {

        for (int i = -WorldSize + 1; i < WorldSize; i += 2)
        {
            for (int j = -WorldSize + 1; j < WorldSize; j += 2)
            {
                GameObject SpaceTile = (GameObject)Instantiate(BackgroundTile);
                SpaceTile.transform.SetParent(this.transform);
                SpaceTile.transform.position = new Vector3(i, j, 10);
            }
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
