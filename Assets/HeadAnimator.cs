using UnityEngine;
using System.Collections;

public class HeadAnimator : MonoBehaviour {
	
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
		myAnimator.Play ("clean_hit");
		Camera.main.GetComponent<CameraShake> ().startShake (0.07f, 0.08f);
		Instantiate (Resources.Load ("ParticleSystems/Spark"), (Vector2)hitLocation, Quaternion.identity);
		Instantiate (Resources.Load ("ParticleSystems/Rocks"), (Vector2)hitLocation, Quaternion.identity);
	}
}
