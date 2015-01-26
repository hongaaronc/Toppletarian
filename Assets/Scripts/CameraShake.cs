using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour 
{
	//float duration;
	float magnitude;
	Vector3 origin;
	float timer;
	// Use this for initialization
	void Start () {
		timer = 0;
		origin = this.transform.position;
		//startShake (1, 1);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (timer > 0) 
		{
			timer -= Time.deltaTime;
			this.transform.position = origin + new Vector3(Random.Range (0.0f, magnitude), Random.Range (0.0f, magnitude), Random.Range (0.0f, magnitude));
		}
		if (timer <= 0) 
		{
			this.transform.position = origin;
		}
	}
	public void startShake(float duration, float mag)
	{
		timer = duration;
		magnitude = mag;
	}
}
