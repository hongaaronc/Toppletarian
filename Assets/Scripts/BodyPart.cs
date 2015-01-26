using UnityEngine;
using System.Collections;

public class BodyPart : MonoBehaviour {

	public float myHealth;
	public float maxHealth;
	public float lastHealth;

	// Use this for initialization
	void Start () {
		lastHealth = myHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if(myHealth<=0.0f){
			if(gameObject.name == "body"){
				if (GameObject.Find("head"))
					GameObject.Find ("head").GetComponent<BodyPart> ().myHealth = 0.0f;
				if (GameObject.Find("arm_front"))
					GameObject.Find ("arm_front").GetComponent<BodyPart> ().myHealth = 0.0f;
				if (GameObject.Find("arm_back"))
					GameObject.Find ("arm_back").GetComponent<BodyPart> ().myHealth = 0.0f;
			}
			if(gameObject.name == "legs"){;
				if (GameObject.Find("body"))
					GameObject.Find ("body").GetComponent<BodyPart> ().myHealth = 0.0f;
			}
			Instantiate (Resources.Load (gameObject.name + "_broke"), transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}

	}
}
