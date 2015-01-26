using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("p1_attack") || Input.GetButtonDown("p2_attack"))
		{
			Application.LoadLevel ("Player"); //load the scene this button leads to
		}
	}
}
