using UnityEngine;
using System.Collections;

public class DeleteOffscreen : MonoBehaviour 
{
	GameObject audiosource;
	// Use this for initialization
	void Start () {
		audiosource = GameObject.Find ("rumblesource");
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -18.0f) {
			Camera.main.GetComponent<CameraShake> ().startShake (1.4f, 0.4f);
			Instantiate (Resources.Load ("ParticleSystems/Destruction"), rigidbody2D.position, Quaternion.identity);
			audiosource.GetComponent<AudioSource>().Play ();
			Destroy(this.gameObject);
		}
	}
}
