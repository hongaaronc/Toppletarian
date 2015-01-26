using UnityEngine;
using System.Collections;

public class BodyPartAnimator : MonoBehaviour {

	Animator myAnimator;
	BodyPart myBodyPart;

	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator> ();
		myBodyPart = GetComponent<BodyPart> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void hit(Vector2 hitLocation) {
		Camera.main.GetComponent<CameraShake> ().startShake (0.07f, 0.08f);
		if (myBodyPart.myHealth<1.0f * myBodyPart.maxHealth/6.0f) {
			myAnimator.Play ("crack5_hit");
			if (myBodyPart.lastHealth >= 1.0f * myBodyPart.maxHealth/6.0f)
				criticalHit (hitLocation);
		}
		else if (myBodyPart.myHealth<2.0f * myBodyPart.maxHealth/6.0f) {
			myAnimator.Play ("crack4_hit");
			if (myBodyPart.lastHealth >= 2.0f * myBodyPart.maxHealth/6.0f)
				criticalHit (hitLocation);
		}
		else if (myBodyPart.myHealth<3.0f * myBodyPart.maxHealth/6.0f) {
			myAnimator.Play ("crack3_hit");
			if (myBodyPart.lastHealth >= 3.0f * myBodyPart.maxHealth/6.0f)
				criticalHit (hitLocation);
		}
		else if (myBodyPart.myHealth<4.0f * myBodyPart.maxHealth/6.0f) {
			myAnimator.Play ("crack2_hit");
			if (myBodyPart.lastHealth >= 4.0f * myBodyPart.maxHealth/6.0f)
				criticalHit (hitLocation);
		}
		else if (myBodyPart.myHealth<5.0f * myBodyPart.maxHealth/6.0f) {
			myAnimator.Play ("crack1_hit");
			if (myBodyPart.lastHealth >= 5.0f * myBodyPart.maxHealth/6.0f)
				criticalHit (hitLocation);
		}
		else if (myBodyPart.myHealth<6.0f * myBodyPart.maxHealth/6.0f) {
			myAnimator.Play ("clean_hit");
		}
		Instantiate (Resources.Load ("ParticleSystems/Spark"), (Vector2)hitLocation, Quaternion.identity);
		Instantiate (Resources.Load ("ParticleSystems/Rocks"), (Vector2)hitLocation, Quaternion.identity);
		myBodyPart.lastHealth = myBodyPart.myHealth;
	}
	void criticalHit(Vector2 hitLocation) {
		print ("Critical Hit!");
		//Spawn explosion prefab + extra particles
		Camera.main.GetComponent<CameraShake> ().startShake (0.1f, 0.2f);
		if(GameObject.Find ("head")){
		GameObject.Find ("head").GetComponent<HeadAnimator> ().hit (hitLocation);
		}
		Instantiate (Resources.Load ("ParticleSystems/BigSpark"), (Vector2)hitLocation, Quaternion.identity);
	}

}
