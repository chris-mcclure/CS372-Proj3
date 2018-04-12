using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speed = 50000f;
	public GameObject boundingLine;


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (this.GetComponent<Renderer>().bounds.Intersects (boundingLine.GetComponent<Renderer>().bounds)) {
			Vector3 directionVector = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, 0);
			GetComponent<Rigidbody> ().MovePosition (transform.position + directionVector);
		}
	}
}
