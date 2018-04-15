using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
	private Rigidbody rb;
	public float speed = 10f;

	private Vector3 movement;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		float moveIntialX = Random.Range (-1.0f, 1.0f);
		float moveIntialZ = Random.Range (-1.0f, 1.0f);

		movement = new Vector3(moveIntialX, 0, moveIntialZ);
		rb.velocity = movement.normalized * speed;
	}

	void OnTriggerEnter (Collider c) {
		if (c.gameObject.tag == "GoalP1" || c.gameObject.tag == "GoalP2") {
			Destroy (gameObject);
		}
	}
}
