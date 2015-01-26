using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

		public int myInput;
		public float myAcceleration;
		bool attackTrigger = false;
		public float baseDamage = 1.0f;
		public float speedDmgMod = 2.0f;
		public float knockbackRatio;
		public GUIText scoredisplay;
		public GUIText wintext;
		int points = 0;
		float wonTimer = 0.0f;
		bool won =  false;
		Animator myAnimator;
		float attackCooldown = 0.7f;
		float attackTimer = 0.0f;
		// Use this for initialization
		void Start ()
		{
				myAnimator = GetComponent<Animator> ();
		}

		// Update is called once per frame
		void Update ()
		{
				print (points);
				rigidbody2D.AddForce (myAcceleration * new Vector2 (Input.GetAxis ("p" + myInput + "_moveX"), Input.GetAxis ("p" + myInput + "_moveY")));
//				if(Input.anyKey){
//					if(Input.GetKey("up")){
//						rigidbody2D.AddForce (myAcceleration * new Vector2 (0,1));
//					}
//					if(Input.GetKey("down")){
//						rigidbody2D.AddForce (myAcceleration * new Vector2 (0,-1));
//					}
//					if(Input.GetKey("right")){
//						rigidbody2D.AddForce (myAcceleration * new Vector2 (1,0));
//					}
//					if(Input.GetKey("left")){
//						rigidbody2D.AddForce (myAcceleration * new Vector2 (-1,0));
//					}
//				}
				if (Input.GetAxis ("p" + myInput + "_attack") == 1.0 && attackTrigger == false && attackTimer <= 0.0f) {
						//Attack Code
						attackTrigger = true;
						attackTimer = attackCooldown;
						myAnimator.Play ("player" + myInput + "_attack");
						if (Physics2D.OverlapCircle (rigidbody2D.position, 0.5f) == null) {
								this.GetComponents<AudioSource> () [0].Play ();
						} else {
								this.GetComponents<AudioSource> () [1].Play ();
								GameObject hitObject = Physics2D.OverlapCircle (rigidbody2D.position, 0.5f).gameObject;
								if (hitObject.name == "head") {
										hitObject.GetComponent<BodyPart> ().myHealth -= baseDamage + speedDmgMod * rigidbody2D.velocity.magnitude;
										points += (int)((baseDamage + speedDmgMod * rigidbody2D.velocity.magnitude) * 10);
										if (hitObject.GetComponent<BodyPart> ().myHealth <= 0.0f) {
												points += 100;
										}
										scoredisplay.text = "" + points;
										hitObject.GetComponent<HeadAnimator> ().hit (rigidbody2D.position);
										rigidbody2D.velocity *= -knockbackRatio;
										print ("Hit head, health: " + hitObject.GetComponent<BodyPart> ().myHealth);
								} else if (hitObject.name == "arm_front") {
										hitObject.GetComponent<BodyPart> ().myHealth -= baseDamage + speedDmgMod * rigidbody2D.velocity.magnitude;
										points += (int)((baseDamage + speedDmgMod * rigidbody2D.velocity.magnitude) * 10);
										if (hitObject.GetComponent<BodyPart> ().myHealth <= 0.0f) {
												points += 50;
										}
										scoredisplay.text = "" + points;

										hitObject.GetComponent<BodyPartAnimator> ().hit (rigidbody2D.position);
										rigidbody2D.velocity *= -knockbackRatio;
										print ("Hit front arm, health: " + hitObject.GetComponent<BodyPart> ().myHealth);
								} else if (hitObject.name == "body") {
										hitObject.GetComponent<BodyPart> ().myHealth -= baseDamage + speedDmgMod * rigidbody2D.velocity.magnitude;
										points += (int)((baseDamage + speedDmgMod * rigidbody2D.velocity.magnitude) * 10);
										if (hitObject.GetComponent<BodyPart> ().myHealth <= 0.0f) {
												points += 100;
												if (GameObject.Find ("head").GetComponent<BodyPart> ().myHealth > 0.0f) {
														points += 100;
												}
												if (GameObject.Find ("arm_back").GetComponent<BodyPart> ().myHealth > 0.0f) {
														points += 50;
												}
												if (GameObject.Find ("arm_front").GetComponent<BodyPart> ().myHealth > 0.0f) {
														points += 50;
												}
										}

										scoredisplay.text = "" + points;

										hitObject.GetComponent<BodyPartAnimator> ().hit (rigidbody2D.position);
										rigidbody2D.velocity *= -knockbackRatio;
										print ("Hit body, health: " + hitObject.GetComponent<BodyPart> ().myHealth);
										;
								} else if (hitObject.name == "arm_back") {
										hitObject.GetComponent<BodyPart> ().myHealth -= baseDamage + speedDmgMod * rigidbody2D.velocity.magnitude;
										points += (int)((baseDamage + speedDmgMod * rigidbody2D.velocity.magnitude) * 10);
										if (hitObject.GetComponent<BodyPart> ().myHealth <= 0.0f) {
												points += 50;
										}
										scoredisplay.text = "" + points;

										hitObject.GetComponent<BodyPartAnimator> ().hit (rigidbody2D.position);
										rigidbody2D.velocity *= -knockbackRatio;
										print ("Hit back arm, health: " + hitObject.GetComponent<BodyPart> ().myHealth);
								} else if (hitObject.name == "legs") {
										hitObject.GetComponent<BodyPart> ().myHealth -= baseDamage + speedDmgMod * rigidbody2D.velocity.magnitude;
										points += (int)((baseDamage + speedDmgMod * rigidbody2D.velocity.magnitude) * 10);
										if (hitObject.GetComponent<BodyPart> ().myHealth <= 0.0f) {
												points += 100;
												if (GameObject.Find ("head").GetComponent<BodyPart> ().myHealth > 0.0f) {
														points += 100;
												}
												if (GameObject.Find ("arm_back").GetComponent<BodyPart> ().myHealth > 0.0f) {
														points += 50;
												}
												if (GameObject.Find ("arm_front").GetComponent<BodyPart> ().myHealth > 0.0f) {
														points += 50;
												}
												if (GameObject.Find ("body").GetComponent<BodyPart> ().myHealth > 0.0f) {
														points += 100;
												}
										scoredisplay.text = "" + points;

					}

										scoredisplay.text = "" + points;

										hitObject.GetComponent<BodyPartAnimator> ().hit (rigidbody2D.position);
										rigidbody2D.velocity *= -knockbackRatio;
										print ("Hit legs, health: " + hitObject.GetComponent<BodyPart> ().myHealth);
								}
						}

				} else if (Input.GetAxis ("p" + myInput + "_attack") == 0.0 && attackTrigger == true) {
						attackTrigger = false;
						//GetComponent<Animator>().Play("idle");
				}
				if (wonTimer > 0.0f) {
						wonTimer -= Time.deltaTime;
				} else if(won==true){
			Application.LoadLevel ("MainMenu");
				}
		if(!GameObject.Find ("legs") && won==false){
		if(GameObject.Find ("Player1").GetComponent<Player>().points > GameObject.Find ("Player2").GetComponent<Player>().points){
			wintext.text = "Everybody wins"+ "\n" +"but Player 1 did more for the cause";
		}else{
			wintext.text = "Everybody wins"+ "\n" +"but Player 2 did more for the cause";
		}
		wonTimer=5.0f;
		won=true;
		}
//		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, rigidbody2D.velocity.x * -2.5f);
				if (attackTimer > 0) {
						attackTimer -= Time.deltaTime;
				}
		scoredisplay.text = "" + points;
		}
}
