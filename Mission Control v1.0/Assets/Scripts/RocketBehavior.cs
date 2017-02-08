using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RocketBehavior : MonoBehaviour {

	public ParticleSystem particleSyst = null;
	public ParticleSystem particleSyst2 = null;

	int numFuelPods = 3;
	int fuelPos = 0;
	float moveSpeed = 5.0f;

	bool launch = false;

	Vector3 prevPos = new Vector3 (0, 0, 0);
	Vector3 prevPrevPos = new Vector3 (0, 0, 0);
	float rocketX = 0;
	float rocketY = 0;
	float initialX = 0;
	float initialY = 0;

	float velocity = 100;

	float angleRad = 70 * ((float)Math.PI) / 180;
	float currAngle =  70 * ((float)Math.PI) / 180;
		
	float time = 0;
	float timeMult = 0.001f;

	// Update is called once per frame
	void FixedUpdate () {
		// Listens for lift off key
		if (Input.GetKeyDown(KeyCode.Return)) {
			Debug.Log("Lift off!!!");
			launch = true;
			particleSyst.Play();
			particleSyst2.Play ();
		}

		// Handles moving rocket
		if (launch == true) {
			// update position of rocket
			Vector3 move = trajectory (); 
			transform.position = move;


			//float ang = Math.Cosh (dVector.x);
			//currAngle = (float)(Math.Cosh (rocketX / (velocity * time))) * (180.0f/(float)Math.PI);
			//transform.rotation = Quaternion.LookRotation(new Vector3((float)Math.Cos(currAngle),(float)Math.Sin(currAngle),0.0f));
			// update orientation of rocket
			//Vector3 directionVector = (new Vector3(0,1,0)) + (prevPos - transform.position).normalized;
			//Vector3 directionVector = transform.position;
			//Quaternion toRotation = Quaternion.FromToRotation(transform.up, directionVector);
			//transform.Rotate (new Vector3 (90, 0, 0));
			rotation();




			//transform.Rotate (0, 0, currAngle, Space.World);
			//transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 0.1f * Time.time);
			// update time
			time += Time.deltaTime * timeMult;
			if (timeMult < 1) {
				timeMult += 0.001f;
			}
			// update position variables
			prevPrevPos = prevPos;
			prevPos = transform.position;
		}

		// Handles dropping fuel pods
		if ( (Input.GetKeyDown(KeyCode.Space)) && (fuelPos < numFuelPods) ) {
			Transform pod = transform.GetChild(0);
			//Vector3 childPos = pod.position;
			//Vector3 breakAwayAngle = new Vector3(childPos.x,0,childPos.z);
			pod.parent = null;
			pod.gameObject.AddComponent<Rigidbody>();
			//pod.gameObject.GetComponent<Rigidbody>().velocity = breakAwayAngle;
			fuelPos += 1;
			changeAngle (3);
		}

	}

	void rotation() {
		/* Rotates the rocket such that it initially starts in the upward
		 * direction. Then it slowly turns towards the user's specified
		 * angle. Finally, it is angled along the tangent line of its path. */
		Vector3 dVector = (transform.position - prevPos).normalized;
		Quaternion vQ = Quaternion.LookRotation (Vector3.forward, dVector);
		Vector3 toVec = vQ.ToEulerAngles();
		if (time < 1) {
			Debug.Log (time.ToString());
			return;
		} else if (Vector3.Distance(transform.eulerAngles, toVec) > 0.01f) {
			transform.rotation = Quaternion.Lerp(transform.rotation, vQ, 0.5f*Time.deltaTime);
		} else {
			transform.rotation = vQ;
		}
	}

	void changeAngle(float amount) {
		// change angle if fuel drop
		velocity = (float) (Math.Sqrt ((4.9 * rocketX) / (Math.Sin (angleRad) * Math.Cos (angleRad)))); //gets curr velocity
		initialX = rocketX;
		initialY = rocketY;
		time = 0; //resets equation
		angleRad += amount * ((float)Math.PI) / 180; // makes new angle
	}

	Vector3 trajectory() {
		rocketX = initialX + velocity * ((float)Math.Cos(angleRad)) * time;
		rocketY = (float) (initialY + velocity * Math.Sin(angleRad) * time - 0.5 * 9.8 * time * time);
		return new Vector3(rocketX,rocketY,0);
	}

	// Use this for initialization
	void Start () {

	}
}
