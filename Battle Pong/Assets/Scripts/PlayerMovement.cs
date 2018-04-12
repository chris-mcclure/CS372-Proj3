using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speed = 5f;
	public GameObject boundingLine;
	private Rigidbody rb;


	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (this.GetComponent<Renderer>().bounds.Intersects (boundingLine.GetComponent<Renderer>().bounds)) {
			Vector3 directionVector = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, 0);
			rb.MovePosition (rb.position + directionVector * Time.deltaTime * speed);
		}

		//rb.position = new Vector3 (Mathf.Clamp (rb.position.x, xMin, xMax),0,0);
	}
}
