using UnityEngine;
using System.Collections;

public class RopeSegment : MonoBehaviour {

	SpringJoint2D mySpringJoint;
	float myAngle;
	float myDistance;

	// Use this for initialization
	void Start () {
		mySpringJoint = GetComponent<SpringJoint2D>();
	}
	
	// Update is called once per frame
	void Update () {
		myAngle = Mathf.Atan2 (
				(mySpringJoint.connectedBody.position.y + mySpringJoint.connectedAnchor.y) - (rigidbody2D.position.y + mySpringJoint.anchor.y),
				(mySpringJoint.connectedBody.position.x + mySpringJoint.connectedAnchor.x) - (rigidbody2D.position.x + mySpringJoint.anchor.x))
				* Mathf.Rad2Deg + 90;
		myDistance = Vector2.Distance (rigidbody2D.position + mySpringJoint.anchor, mySpringJoint.connectedBody.position + mySpringJoint.connectedAnchor);
		transform.localScale = new Vector3 (transform.localScale.x, myDistance, transform.localScale.z);
		transform.localEulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, myAngle);
	}
}
