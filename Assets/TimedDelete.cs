using UnityEngine;
using System.Collections;

public class TimedDelete : MonoBehaviour {

	float myTimer = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		myTimer -= Time.deltaTime;
		if (myTimer <= 0) {
			Destroy(this.gameObject);
		}
	}
}
