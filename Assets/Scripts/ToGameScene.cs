using UnityEngine;
using System.Collections;

public class ToGameScene : MonoBehaviour 
{
	public GUIText btnStart;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown()
	{
		Application.LoadLevel ("Player"); //load the scene this button leads to
	}

	//for mouse hover.
	void OnMouseEnter()
	{
		btnStart.color = Color.red;
	}
	void OnMouseExit()
	{
		btnStart.color = Color.black;
	}
}
