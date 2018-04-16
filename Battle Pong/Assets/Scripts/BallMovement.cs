using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
	private Rigidbody rb;
	private GameObject lastHitBy = null;
	public float speed = 10f;

	private Vector3 movement;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		float moveIntialX = Random.Range (-0.9f, 0.9f);
		float moveIntialZ = Random.Range (-1.0f, 1.0f);

		movement = new Vector3(moveIntialX, 0, moveIntialZ);
		rb.velocity = movement.normalized * speed;
	}

	void OnTriggerEnter (Collider c) {
		ScoreKeeping ();
		if (c.gameObject.tag == "GoalP1" || c.gameObject.tag == "GoalP2") {
			Destroy (gameObject);

		}
	}

	void OnCollisionEnter (Collision c) {
		if (c.gameObject.tag == "Player") { 
			lastHitBy = GameObject.Find (c.gameObject.name);
		}

	}

	void ScoreKeeping() {
		GameObject P1 = GameObject.Find ("P1");
		PlayerMovement P1Script = (PlayerMovement) P1.GetComponent(typeof(PlayerMovement));

		GameObject P2 = GameObject.Find ("P2");
		PlayerMovement P2Script = (PlayerMovement) P2.GetComponent(typeof(PlayerMovement));

		if (lastHitBy.name == "P1") {
			P1Script.setScore (P1Script.getScore ()+1);
			P2Script.setScore (P2Script.getScore ()-1);
		}
		if (lastHitBy.name == "P2") {
			P2Script.setScore (P2Script.getScore ()+1);
			P1Script.setScore (P1Script.getScore ()-1);
		}
	}

}
