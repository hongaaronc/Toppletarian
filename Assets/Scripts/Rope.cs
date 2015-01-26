using UnityEngine;
using System.Collections;

public class Rope : MonoBehaviour {

	public int numSegments;
	public float segmentLength;
	public float segmentTension;
	public Rigidbody2D endConnectedBody;
	public Vector2 endConnectedAnchor;
	GameObject initialSegment;

	// Use this for initialization
	void Start () {
		for (int i=0; i<numSegments; i++) {
			GameObject newSegment = (GameObject)Instantiate (Resources.Load ("RopeSegment"), transform.position - segmentLength * i * Vector3.down, Quaternion.identity);
			newSegment.transform.parent = transform;
			if (i==0)
				initialSegment = newSegment;
			newSegment.gameObject.name = "RopeSegment" + i;
			newSegment.GetComponent<SpringJoint2D>().distance = segmentLength;
			newSegment.GetComponent<SpringJoint2D>().frequency = segmentTension;
		}
		for (int i=0; i<numSegments; i++) {
			if (i==0) {
				GetComponent<HingeJoint2D>().connectedBody = transform.Find ("RopeSegment"+i).rigidbody2D;
			}
			if (i<numSegments-1)
				transform.Find("RopeSegment"+i).GetComponent<SpringJoint2D>().connectedBody = transform.Find("RopeSegment"+(i+1)).rigidbody2D;
			else {
				transform.Find("RopeSegment"+i).GetComponent<SpringJoint2D>().connectedBody = endConnectedBody;
				transform.Find("RopeSegment"+i).GetComponent<SpringJoint2D>().connectedAnchor = endConnectedAnchor;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
//		initialSegment.transform.localPosition = Vector3.zero;
//		initialSegment.rigidbody2D.velocity = Vector2.zero;
	}
}
